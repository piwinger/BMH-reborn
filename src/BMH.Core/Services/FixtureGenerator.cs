using BMH.Core.Domain.Entities;

namespace BMH.Core.Services;

public sealed class FixtureGenerator
{
    public void Generate(League league)
    {
        if (league.Clubs.Count % 2 != 0)
            throw new InvalidOperationException("League must contain an even number of clubs.");

        var clubs = league.Clubs.ToList();

        Club fixedClub = clubs[0];

        var rotation = clubs.Skip(1).ToList();

        int rounds = clubs.Count - 1;
        int matchesPerRound = clubs.Count / 2;

        for (int round = 0; round < rounds; round++)
        {
            var current = new List<Club>();

            current.Add(fixedClub);
            current.AddRange(rotation);

            for (int i = 0; i < matchesPerRound; i++)
            {
                Club home = current[i];
                Club away = current[current.Count - 1 - i];

                if (round % 2 == 1)
                    (home, away) = (away, home);

                league.Season.AddFixture(
                    new Fixture(round + 1, home, away));

                league.Season.AddFixture(
                    new Fixture(round + rounds + 1, away, home));
            }

            Club last = rotation[^1];

            rotation.RemoveAt(rotation.Count - 1);

            rotation.Insert(0, last);
        }
    }
}