using BMH.Core.Domain.Entities;
using BMH.Core.Services;

namespace BMH.Tests.Services;

public class MatchSimulatorTests
{
    [Fact]
    public void Simulate_Should_Create_Result_For_Fixture()
    {
        var home = CreateClub("Home");
        var away = CreateClub("Away");
        var fixture = new Fixture(1, home, away);

        var result = new MatchSimulator().Simulate(fixture);

        Assert.Same(fixture, result.Fixture);
        Assert.InRange(result.HomeGoals, 0, 5);
        Assert.InRange(result.AwayGoals, 0, 5);
    }

    private static Club CreateClub(string name)
        => new(name, name, name, 1_000_000m, 50);
}
