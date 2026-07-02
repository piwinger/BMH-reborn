using BMH.Core.Domain.Entities;

namespace BMH.Core.Services;

public sealed class LeagueGenerator
{
    private readonly PlayerGenerator _playerGenerator;

    public LeagueGenerator()
        : this(new PlayerGenerator())
    {
    }

    public LeagueGenerator(PlayerGenerator playerGenerator)
    {
        _playerGenerator = playerGenerator;
    }

    public League CreateBundesliga()
    {
        return CreateBundesliga(CreateBundesligaClubs());
    }

    public League CreateBundesliga(IEnumerable<Club> clubs)
    {
        var league = new League("Bundesliga");

        foreach (var club in clubs)
        {
            AddClub(league, club);
        }

        return league;
    }

    private void AddClub(League league, Club club)
    {
        _playerGenerator.GenerateSquad(club);
        league.AddClub(club);
    }

    private static IReadOnlyList<Club> CreateBundesligaClubs()
    {
        return
        [
            new Club("Bayern München", "FCB", "München", 55_000_000m, 95),
            new Club("Borussia Dortmund", "BVB", "Dortmund", 42_000_000m, 90),
            new Club("Werder Bremen", "SVW", "Bremen", 31_000_000m, 86),
            new Club("Hamburger SV", "HSV", "Hamburg", 29_000_000m, 84),
            new Club("Eintracht Frankfurt", "SGE", "Frankfurt", 26_000_000m, 82),
            new Club("1. FC Kaiserslautern", "FCK", "Kaiserslautern", 24_000_000m, 80),
            new Club("VfB Stuttgart", "VFB", "Stuttgart", 28_000_000m, 83),
            new Club("Borussia Mönchengladbach", "BMG", "Mönchengladbach", 23_000_000m, 79),
            new Club("Karlsruher SC", "KSC", "Karlsruhe", 18_000_000m, 74),
            new Club("Bayer Leverkusen", "B04", "Leverkusen", 34_000_000m, 87),
            new Club("Dynamo Dresden", "DYN", "Dresden", 15_000_000m, 70),
            new Club("SC Freiburg", "SCF", "Freiburg", 14_000_000m, 69),
            new Club("TSV 1860 München", "1860", "München", 16_000_000m, 71),
            new Club("MSV Duisburg", "MSV", "Duisburg", 15_000_000m, 70),
            new Club("1. FC Köln", "KOE", "Köln", 20_000_000m, 76),
            new Club("FC St. Pauli", "STP", "Hamburg", 12_000_000m, 66),
            new Club("VfL Bochum", "BOC", "Bochum", 14_000_000m, 68),
            new Club("KFC Uerdingen", "KFC", "Krefeld", 13_000_000m, 67)
        ];
    }
}
