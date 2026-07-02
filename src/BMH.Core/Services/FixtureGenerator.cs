using BMH.Core.Domain.Entities;
using BMH.Core.Services.Scheduling;

namespace BMH.Core.Services;

public sealed class FixtureGenerator
{
    private readonly RoundRobinScheduler _scheduler = new();

    public void Generate(League league)
    {
        var rounds = _scheduler.Generate(league.Clubs);

        int roundCount = rounds.Count;

        for (int round = 0; round < roundCount; round++)
        {
            foreach (var match in rounds[round])
            {
                // Hinrunde
                league.Season.AddFixture(
                    new Fixture(
                        round + 1,
                        match.Home,
                        match.Away));

                // Rückrunde
                league.Season.AddFixture(
                    new Fixture(
                        round + 1 + roundCount,
                        match.Away,
                        match.Home));
            }
        }
    }
}