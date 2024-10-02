using System.Collections.Immutable;
using RandomPreferenceGenerator.Domain.Model;

namespace RandomPreferenceGenerator.Service;

// public class GaleShapleyPairsCreationService : IPairsCreationService
// {
//     
//     public ImmutableList<MatchingPair> Create(Preferences preferences, IImmutableDictionary<int, Junior> juniors, IImmutableDictionary<int, Teamlead> teamleads)
//     {
//         var juniorPreferences = new Dictionary<int, PriorityQueue<int, int>>();
//         var teamleadPreferences = new Dictionary<int, PriorityQueue<int, int>>();
//
//         foreach (var pair in preferences.IdsToScores)
//         {
//             {
//                 if (!juniorPreferences.TryGetValue(pair.Key.JuniorId, out PriorityQueue<int, int>? value))
//                 {
//                     value = new PriorityQueue<int, int>();
//                     juniorPreferences[pair.Key.JuniorId] = value;
//                 }
//
//                 value.Enqueue(pair.Key.TeamleadId, pair.Value.TeamleadScore);
//             }
//
//             {
//                 if (!teamleadPreferences.TryGetValue(pair.Key.TeamleadId, out PriorityQueue<int, int>? value))
//                 {
//                     value = new PriorityQueue<int, int>();
//                     teamleadPreferences[pair.Key.TeamleadId] = value;
//                 }
//                 
//                 value.Enqueue(pair.Key.JuniorId, pair.Value.JuniorScore);
//             }
//         }
//         
//         var unoccupiedJuniors = new HashSet<int>(juniors.Keys);
//         var unoccupiedTeamleads = new HashSet<int>(teamleads.Keys);
//         
//         var resultPairs = new List<MatchingPair>();
//         
//         while (unoccupiedJuniors.Any() && unoccupiedTeamleads.Any())
//         {
//             var currentJunior = unoccupiedJuniors.First();
//             var currentTeamlead = unoccupiedTeamleads.First();
//             
//             unoccupiedJuniors.Remove(currentJunior);
//             unoccupiedTeamleads.Remove(currentTeamlead);
//     }
// }