using BMH.Core.Services;

namespace BMH.Tests.Services;

public class ClubJsonLoaderTests
{
    [Fact]
    public void Load_Should_Load_Bundesliga_Clubs_From_Json()
    {
        var clubs = new ClubJsonLoader().Load(GetBundesligaClubsPath());

        Assert.Equal(18, clubs.Count);
        Assert.Contains(clubs, club => club.ShortName == "FCB");
        Assert.Contains(clubs, club => club.ShortName == "BVB");
        Assert.All(clubs, club => Assert.Empty(club.Players));
    }

    [Fact]
    public void Loaded_Clubs_Should_Create_Playable_League()
    {
        var clubs = new ClubJsonLoader().Load(GetBundesligaClubsPath());

        var league = new LeagueGenerator().CreateBundesliga(clubs);

        Assert.Equal(18, league.Clubs.Count);
        Assert.All(league.Clubs, club => Assert.Equal(20, club.Players.Count));
    }

    private static string GetBundesligaClubsPath()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);

        while (directory is not null)
        {
            var path = Path.Combine(
                directory.FullName,
                "assets",
                "databases",
                "bundesliga1994",
                "clubs.json");

            if (File.Exists(path))
                return path;

            directory = directory.Parent;
        }

        throw new FileNotFoundException("Could not find Bundesliga clubs fixture.");
    }
}
