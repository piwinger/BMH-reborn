using BMH.Core.Domain.Entities;

namespace BMH.Core.Services.Scheduling;

public sealed class RoundRobinScheduler
{
    public IReadOnlyList<IReadOnlyList<(Club Home, Club Away)>> Generate(IReadOnlyList<Club> clubs)
    {
        if (clubs.Count < 2)
            throw new ArgumentException("At least two clubs are required.");

        if (clubs.Count % 2 != 0)
            throw new ArgumentException("Number of clubs must be even.");

        var teams = clubs.ToList();

        int rounds = teams.Count - 1;
        int matchesPerRound = teams.Count / 2;

        var schedule = new List<IReadOnlyList<(Club Home, Club Away)>>();

        for (int round = 0; round < rounds; round++)
        {
            var matchDay = new List<(Club Home, Club Away)>();

            for (int i = 0; i < matchesPerRound; i++)
            {
                var home = teams[i];
                var away = teams[teams.Count - 1 - i];

                if (round % 2 == 1)
                    (home, away) = (away, home);

                matchDay.Add((home, away));
            }

            schedule.Add(matchDay);

            // Rotation (erste Mannschaft bleibt stehen)
            var last = teams[^1];
            teams.RemoveAt(teams.Count - 1);
            teams.Insert(1, last);
        }

        return schedule;
    }
}