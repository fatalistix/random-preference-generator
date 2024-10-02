using System.Collections.Immutable;

namespace RandomPreferenceGenerator.Domain.Model;

public readonly record struct Teamlead(int Id, string Name)
{
    public override string ToString()
    {
        return $"{Id};{Name}";
    }
}

public readonly record struct TeamleadIdWithScore(int Id, int Score);