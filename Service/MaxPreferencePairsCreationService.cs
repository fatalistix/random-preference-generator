using System.Collections.Immutable;
using RandomPreferenceGenerator.Domain.Model;

namespace RandomPreferenceGenerator.Service;

public class MaxPreferencePairsCreationService : IPairsCreationService
{
    public ImmutableList<MatchingPair> Create(
        Preferences preferences, 
        IImmutableDictionary<int, Junior> juniors, 
        IImmutableDictionary<int, Teamlead> teamleads)
    {
        var usedTeamleads = new HashSet<int>();
        var usedJuniors = new HashSet<int>();

        var sumList = preferences.IdsToScores.Select(pair => new JuniorTeamleadSum(pair.Key.JuniorId, pair.Key.TeamleadId,
            pair.Value.TeamleadScore + pair.Value.JuniorScore)).ToList();
        
        sumList.Sort((o1, o2) => o2.SumScore - o1.SumScore);

        var resultPairs = new List<MatchingPair>();
        foreach (var pair in sumList)
        {
            if (usedTeamleads.Contains(pair.TeamleadId) || usedJuniors.Contains(pair.JuniorId))
            {
                continue;
            }

            usedTeamleads.Add(pair.TeamleadId);
            usedJuniors.Add(pair.JuniorId);

            var scores = preferences.IdsToScores[new JuniorTeamleadId(pair.JuniorId, pair.TeamleadId)];
            resultPairs.Add(new MatchingPair(juniors[pair.JuniorId], teamleads[pair.TeamleadId], scores.JuniorScore, scores.TeamleadScore));
        }

        return resultPairs.ToImmutableList();
    }
}

internal readonly record struct JuniorTeamleadSum(int JuniorId, int TeamleadId, int SumScore);