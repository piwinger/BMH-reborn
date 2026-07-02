namespace BMH.Core.Domain.Entities;

public sealed class MatchResult
{
    public MatchResult(
        Fixture fixture,
        int homeGoals,
        int awayGoals)
    {
        Fixture = fixture;
        HomeGoals = homeGoals;
        AwayGoals = awayGoals;
    }

    public Fixture Fixture { get; }

    public int HomeGoals { get; }

    public int AwayGoals { get; }
}