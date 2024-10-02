using System.Collections.Immutable;
using RandomPreferenceGenerator.Domain.Model;

namespace RandomPreferenceGenerator.Service;

public class AverageHarmonicValueCalculationService
{
    public double Calculate(ImmutableList<MatchingPair> matchingPairs)
    {
        var n = matchingPairs.Count * 2;
        var sum = matchingPairs.Sum(pair => 1.0 / pair.JuniorScore + 1.0 / pair.TeamleadScore);

        return n / sum;
    }
}