using System.Collections.Immutable;
using RandomPreferenceGenerator.Domain.Extension;
using RandomPreferenceGenerator.Domain.Model;

namespace RandomPreferenceGenerator.Service;

public class HackathonService
{
    public Preferences Hold(IImmutableSet<Teamlead> teamleads, IImmutableSet<Junior> juniors)
    {
        var teamleadPreferences = new Dictionary<JuniorTeamleadId, int>(teamleads.Count);
        var juniorPreferences = new Dictionary<JuniorTeamleadId, int>(juniors.Count);
        
        var juniorsCopy = juniors.ToList();
        var teamleadsCopy = teamleads.ToList();

        foreach (var teamlead in teamleads)
        {
            juniorsCopy.Shuffle();

            for (var i = 0; i < juniorsCopy.Count; ++i)
            {
                teamleadPreferences.Add(
                    new JuniorTeamleadId(
                        JuniorId: juniorsCopy[i].Id,
                        TeamleadId: teamlead.Id),
                    20 - i);
            }
        }

        foreach (var junior in juniors)
        {
            teamleadsCopy.Shuffle();

            for (var i = 0; i < teamleadsCopy.Count; ++i)
            {
                juniorPreferences.Add(
                    new JuniorTeamleadId(
                        JuniorId: junior.Id,
                        TeamleadId: teamleadsCopy[i].Id),
                    20 - i);
            }
        }

        var result = new Dictionary<JuniorTeamleadId, JuniorTeamleadScore>();
        
        foreach (var t in teamleads)
        {
            foreach (var j in juniors)
            {
                var jt = new JuniorTeamleadId(j.Id, t.Id);
                var teamleadScore = juniorPreferences[jt];
                var juniorScore = teamleadPreferences[jt];

                result[jt] = new JuniorTeamleadScore(juniorScore, teamleadScore);
            }
        }
        
        return new Preferences(result.ToImmutableDictionary());
    }
}