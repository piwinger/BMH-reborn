using BMH.Core.Services;

namespace BMH.Tests.Services;

public class FixtureGeneratorTests
{
    [Fact]
    public void Should_Create_306_Fixtures()
    {
        var league = new LeagueGenerator().CreateBundesliga();

        new FixtureGenerator().Generate(league);

        Assert.Equal(306, league.Season.Fixtures.Count);
    }


    [Fact]
    public void Every_Matchday_Should_Contain_9_Matches()
    {
        var league = new LeagueGenerator().CreateBundesliga();

        new FixtureGenerator().Generate(league);

        for (int day = 1; day <= 34; day++)
        {
            Assert.Equal(
                9,
                league.Season.Fixtures.Count(f => f.MatchDay == day));
        }
    }

    [Fact]
    public void Every_Club_Should_Play_34_Matches()
    {
        var league = new LeagueGenerator().CreateBundesliga();

        new FixtureGenerator().Generate(league);

        foreach (var club in league.Clubs)
        {
            int matches = league.Season.Fixtures.Count(f =>
                f.HomeClub == club ||
                f.AwayClub == club);

            Assert.Equal(34, matches);
        }
    }

}