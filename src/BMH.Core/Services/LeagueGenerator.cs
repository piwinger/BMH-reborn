using BMH.Core.Domain.Entities;

namespace BMH.Core.Services;

public sealed class LeagueGenerator
{
    public League CreateBundesliga()
    {
        var league = new League("Bundesliga", 1994);

        league.AddClub(new Club("Bayern München", "FCB", "München", 55_000_000m, 95));
        league.AddClub(new Club("Borussia Dortmund", "BVB", "Dortmund", 42_000_000m, 90));
        league.AddClub(new Club("Werder Bremen", "SVW", "Bremen", 31_000_000m, 86));
        league.AddClub(new Club("Hamburger SV", "HSV", "Hamburg", 29_000_000m, 84));
        league.AddClub(new Club("Eintracht Frankfurt", "SGE", "Frankfurt", 26_000_000m, 82));
        league.AddClub(new Club("1. FC Kaiserslautern", "FCK", "Kaiserslautern", 24_000_000m, 80));
        league.AddClub(new Club("VfB Stuttgart", "VFB", "Stuttgart", 28_000_000m, 83));
        league.AddClub(new Club("Borussia Mönchengladbach", "BMG", "Mönchengladbach", 23_000_000m, 79));
        league.AddClub(new Club("Karlsruher SC", "KSC", "Karlsruhe", 18_000_000m, 74));
        league.AddClub(new Club("Bayer Leverkusen", "B04", "Leverkusen", 34_000_000m, 87));
        league.AddClub(new Club("Dynamo Dresden", "DYN", "Dresden", 15_000_000m, 70));
        league.AddClub(new Club("SC Freiburg", "SCF", "Freiburg", 14_000_000m, 69));
        league.AddClub(new Club("TSV 1860 München", "1860", "München", 16_000_000m, 71));
        league.AddClub(new Club("MSV Duisburg", "MSV", "Duisburg", 15_000_000m, 70));
        league.AddClub(new Club("1. FC Köln", "KOE", "Köln", 20_000_000m, 76));
        league.AddClub(new Club("FC St. Pauli", "STP", "Hamburg", 12_000_000m, 66));
        league.AddClub(new Club("VfL Bochum", "BOC", "Bochum", 14_000_000m, 68));
        league.AddClub(new Club("KFC Uerdingen", "KFC", "Krefeld", 13_000_000m, 67));

        return league;
    }
}