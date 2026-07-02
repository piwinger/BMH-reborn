using BMH.Core.Domain.Entities;
using BMH.Core.Services;

namespace BMH.Tests.Services;

public class TableCalculatorTests
{
    [Fact]
    public void Calculate_Should_Order_By_Points_GoalDifference_And_GoalsFor()
    {
        var league = new League("Test League");
        var alpha = CreateClub("Alpha");
        var beta = CreateClub("Beta");
        var gamma = CreateClub("Gamma");
        var delta = CreateClub("Delta");

        league.AddClub(alpha);
        league.AddClub(beta);
        league.AddClub(gamma);
        league.AddClub(delta);

        AddResult(league, 1, alpha, beta, 3, 0);
        AddResult(league, 1, gamma, delta, 2, 1);
        AddResult(league, 2, alpha, gamma, 1, 1);
        AddResult(league, 2, beta, delta, 1, 4);

        var table = new TableCalculator().Calculate(league);

        Assert.Collection(
            table,
            entry =>
            {
                Assert.Same(alpha, entry.Club);
                Assert.Equal(4, entry.Points);
                Assert.Equal(3, entry.GoalDifference);
            },
            entry =>
            {
                Assert.Same(gamma, entry.Club);
                Assert.Equal(4, entry.Points);
                Assert.Equal(1, entry.GoalDifference);
            },
            entry =>
            {
                Assert.Same(delta, entry.Club);
                Assert.Equal(3, entry.Points);
            },
            entry =>
            {
                Assert.Same(beta, entry.Club);
                Assert.Equal(0, entry.Points);
            });
    }

    private static void AddResult(
        League league,
        int matchDay,
        Club home,
        Club away,
        int homeGoals,
        int awayGoals)
    {
        var fixture = new Fixture(matchDay, home, away);
        league.Season.AddFixture(fixture);
        league.Season.AddResult(new MatchResult(fixture, homeGoals, awayGoals));
    }

    private static Club CreateClub(string name)
        => new(name, name, name, 1_000_000m, 50);
}
