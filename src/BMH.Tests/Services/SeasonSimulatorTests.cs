using BMH.Core.Services;

namespace BMH.Tests.Services;

public class SeasonSimulatorTests
{
    [Fact]
    public void PlayCurrentMatchDay_Should_Add_Results_And_Advance_MatchDay()
    {
        var league = new LeagueGenerator().CreateBundesliga();
        new FixtureGenerator().Generate(league);

        new SeasonSimulator().PlayCurrentMatchDay(league);

        Assert.Equal(9, league.Season.Results.Count);
        Assert.Equal(2, league.Season.CurrentMatchDay);
    }

    [Fact]
    public void PlayMatchDay_Should_Not_Allow_Same_Fixture_Twice()
    {
        var league = new LeagueGenerator().CreateBundesliga();
        var simulator = new SeasonSimulator();
        new FixtureGenerator().Generate(league);

        simulator.PlayMatchDay(league, 1);

        Assert.Throws<InvalidOperationException>(() => simulator.PlayMatchDay(league, 1));
    }

    [Fact]
    public void PlayRemainingSeason_Should_Play_All_Fixtures()
    {
        var league = new LeagueGenerator().CreateBundesliga();
        new FixtureGenerator().Generate(league);

        new SeasonSimulator().PlayRemainingSeason(league);

        Assert.True(league.Season.IsCompleted);
        Assert.Equal(306, league.Season.Results.Count);
        Assert.Equal(35, league.Season.CurrentMatchDay);
    }

    [Fact]
    public void PlayRemainingSeason_Should_Result_In_34_Matches_Per_Club()
    {
        var league = new LeagueGenerator().CreateBundesliga();
        new FixtureGenerator().Generate(league);

        new SeasonSimulator().PlayRemainingSeason(league);

        var table = new TableCalculator().Calculate(league);

        Assert.All(table, entry => Assert.Equal(34, entry.MatchesPlayed));
    }
}
