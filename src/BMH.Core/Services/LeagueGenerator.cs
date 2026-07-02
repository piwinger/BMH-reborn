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
        var league = new League("Bundesliga");

        AddClub(league, new Club("Bayern München", "FCB", "München", 55_000_000m, 95));
        AddClub(league, new Club("Borussia Dortmund", "BVB", "Dortmund", 42_000_000m, 90));
        AddClub(league, new Club("Werder Bremen", "SVW", "Bremen", 31_000_000m, 86));
        AddClub(league, new Club("Hamburger SV", "HSV", "Hamburg", 29_000_000m, 84));
        AddClub(league, new Club("Eintracht Frankfurt", "SGE", "Frankfurt", 26_000_000m, 82));
        AddClub(league, new Club("1. FC Kaiserslautern", "FCK", "Kaiserslautern", 24_000_000m, 80));
        AddClub(league, new Club("VfB Stuttgart", "VFB", "Stuttgart", 28_000_000m, 83));
        AddClub(league, new Club("Borussia Mönchengladbach", "BMG", "Mönchengladbach", 23_000_000m, 79));
        AddClub(league, new Club("Karlsruher SC", "KSC", "Karlsruhe", 18_000_000m, 74));
        AddClub(league, new Club("Bayer Leverkusen", "B04", "Leverkusen", 34_000_000m, 87));
        AddClub(league, new Club("Dynamo Dresden", "DYN", "Dresden", 15_000_000m, 70));
        AddClub(league, new Club("SC Freiburg", "SCF", "Freiburg", 14_000_000m, 69));
        AddClub(league, new Club("TSV 1860 München", "1860", "München", 16_000_000m, 71));
        AddClub(league, new Club("MSV Duisburg", "MSV", "Duisburg", 15_000_000m, 70));
        AddClub(league, new Club("1. FC Köln", "KOE", "Köln", 20_000_000m, 76));
        AddClub(league, new Club("FC St. Pauli", "STP", "Hamburg", 12_000_000m, 66));
        AddClub(league, new Club("VfL Bochum", "BOC", "Bochum", 14_000_000m, 68));
        AddClub(league, new Club("KFC Uerdingen", "KFC", "Krefeld", 13_000_000m, 67));

        return league;
    }

    private void AddClub(League league, Club club)
    {
        _playerGenerator.GenerateSquad(club);
        league.AddClub(club);
    }
}
