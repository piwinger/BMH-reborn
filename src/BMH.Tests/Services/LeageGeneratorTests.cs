using BMH.Core.Services;

namespace BMH.Tests;

public class LeagueGeneratorTests
{
    [Fact]
    public void CreateBundesliga_Should_Create_18_Clubs()
    {
        var generator = new LeagueGenerator();

        var league = generator.CreateBundesliga();

        Assert.Equal(18, league.Clubs.Count);
    }
}