using BMH.Core.Domain.Entities;

namespace BMH.Core.Services;

public sealed class TableCalculator
{
    public IReadOnlyList<LeagueTableEntry> Calculate(League league)
    {
        var table = league.Clubs
            .Select(c => new LeagueTableEntry(c))
            .ToDictionary(e => e.Club);

        foreach (var result in league.Season.Results)
        {
            table[result.Fixture.HomeClub]
                .AddMatch(result.HomeGoals, result.AwayGoals);

            table[result.Fixture.AwayClub]
                .AddMatch(result.AwayGoals, result.HomeGoals);
        }

        return table.Values
            .OrderByDescending(t => t.Points)
            .ThenByDescending(t => t.GoalDifference)
            .ThenByDescending(t => t.GoalsFor)
            .ToList();
    }
}