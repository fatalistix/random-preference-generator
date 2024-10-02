namespace RandomPreferenceGenerator.Domain.Model;

public readonly record struct MatchingPair(
    Junior Junior, 
    Teamlead Teamlead, 
    int JuniorScore, 
    int TeamleadScore);