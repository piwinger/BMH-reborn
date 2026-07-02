using BMH.Core.Domain.Entities;
using BMH.Core.Domain.Enums;

namespace BMH.Core.Services;

public sealed class MatchSimulator
{
    private readonly Random _random;

    public MatchSimulator()
        : this(new Random())
    {
    }

    public MatchSimulator(Random random)
    {
        _random = random;
    }

    public MatchResult Simulate(Fixture fixture)
    {
        int homeAttack = CalculateAttackStrength(fixture.HomeClub) + 4;
        int awayAttack = CalculateAttackStrength(fixture.AwayClub);
        int homeDefense = CalculateDefenseStrength(fixture.HomeClub) + 2;
        int awayDefense = CalculateDefenseStrength(fixture.AwayClub);

        return new MatchResult(
            fixture,
            GenerateGoals(homeAttack, awayDefense),
            GenerateGoals(awayAttack, homeDefense));
    }

    private int GenerateGoals(int attackStrength, int defenseStrength)
    {
        double pressure = 1.2 + (attackStrength - defenseStrength) / 32.0;
        pressure = Math.Clamp(pressure, 0.15, 3.8);

        int goals = 0;

        for (int chance = 0; chance < 6; chance++)
        {
            double probability = pressure / (chance + 2.4);

            if (_random.NextDouble() < probability)
                goals++;
        }

        return goals;
    }

    private static int CalculateAttackStrength(Club club)
    {
        if (club.Players.Count == 0)
            return club.Reputation;

        double strikerStrength = AverageOverall(club, Position.Striker, club.Reputation);
        double midfieldStrength = AverageOverall(club, Position.Midfielder, club.Reputation);
        double squadStrength = club.Players.Average(p => p.Overall);

        return (int)Math.Round(
            strikerStrength * 0.45 +
            midfieldStrength * 0.35 +
            squadStrength * 0.20);
    }

    private static int CalculateDefenseStrength(Club club)
    {
        if (club.Players.Count == 0)
            return club.Reputation;

        double goalkeeperStrength = AverageOverall(club, Position.Goalkeeper, club.Reputation);
        double defenderStrength = AverageOverall(club, Position.Defender, club.Reputation);
        double midfieldStrength = AverageOverall(club, Position.Midfielder, club.Reputation);

        return (int)Math.Round(
            goalkeeperStrength * 0.30 +
            defenderStrength * 0.45 +
            midfieldStrength * 0.25);
    }

    private static double AverageOverall(
        Club club,
        Position position,
        int fallback)
    {
        var players = club.Players
            .Where(p => p.Position == position)
            .ToList();

        return players.Count == 0
            ? fallback
            : players.Average(p => p.Overall);
    }
}
