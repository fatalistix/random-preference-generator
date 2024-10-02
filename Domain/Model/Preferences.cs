using System.Collections.Immutable;

namespace RandomPreferenceGenerator.Domain.Model;

public readonly record struct Preferences(IImmutableDictionary<JuniorTeamleadId, JuniorTeamleadScore> IdsToScores);