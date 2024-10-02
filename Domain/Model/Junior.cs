using System.Collections.Immutable;

namespace RandomPreferenceGenerator.Domain.Model;

public readonly record struct Junior(int Id, string Name)
{
    public override string ToString()
    {
        return $"{Id};{Name}";
    }
}

public readonly record struct JuniorIdWithScore(int Id, int Score);