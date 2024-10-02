using System.Collections.Immutable;
using RandomPreferenceGenerator.Domain.Model;

namespace RandomPreferenceGenerator.Service;

public interface IPairsCreationService
{
    public ImmutableList<MatchingPair> Create(
        Preferences preferences, 
        IImmutableDictionary<int, Junior> juniors,
        IImmutableDictionary<int, Teamlead> teamleads);
}