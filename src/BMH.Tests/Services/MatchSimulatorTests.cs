using BMH.Core.Domain.Entities;
using BMH.Core.Domain.Enums;
using BMH.Core.Domain.ValueObjects;
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

        var result = new MatchSimulator(new Random(1)).Simulate(fixture);

        Assert.Same(fixture, result.Fixture);
        Assert.InRange(result.HomeGoals, 0, 6);
        Assert.InRange(result.AwayGoals, 0, 6);
    }

    [Fact]
    public void Stronger_Club_Should_Win_More_Often()
    {
        var strong = new Club("Strong", "STR", "Strong", 1_000_000m, 95);
        var weak = new Club("Weak", "WEA", "Weak", 1_000_000m, 55);
        var simulator = new MatchSimulator(new Random(2));

        int strongWins = 0;
        int weakWins = 0;

        for (int i = 0; i < 200; i++)
        {
            var result = simulator.Simulate(new Fixture(i + 1, strong, weak));

            if (result.HomeGoals > result.AwayGoals)
                strongWins++;
            else if (result.AwayGoals > result.HomeGoals)
                weakWins++;
        }

        Assert.True(strongWins > weakWins);
    }

    [Fact]
    public void Player_Attributes_Should_Influence_Match_Strength()
    {
        var strong = CreateClub("Strong");
        var weak = CreateClub("Weak");

        AddSquad(strong, 92);
        AddSquad(weak, 52);

        var simulator = new MatchSimulator(new Random(3));
        int strongGoals = 0;
        int weakGoals = 0;

        for (int i = 0; i < 100; i++)
        {
            var result = simulator.Simulate(new Fixture(i + 1, strong, weak));

            strongGoals += result.HomeGoals;
            weakGoals += result.AwayGoals;
        }

        Assert.True(strongGoals > weakGoals);
    }

    private static Club CreateClub(string name)
        => new(name, name, name, 1_000_000m, 50);

    private static void AddSquad(Club club, int overall)
    {
        AddPlayer(club, Position.Goalkeeper, overall);

        for (int i = 0; i < 4; i++)
            AddPlayer(club, Position.Defender, overall);

        for (int i = 0; i < 4; i++)
            AddPlayer(club, Position.Midfielder, overall);

        for (int i = 0; i < 2; i++)
            AddPlayer(club, Position.Striker, overall);
    }

    private static void AddPlayer(
        Club club,
        Position position,
        int overall)
    {
        club.AddPlayer(new Player(
            "Test",
            position.ToString(),
            position,
            25,
            new PlayerAttributes(overall, overall, overall),
            overall));
    }
}
