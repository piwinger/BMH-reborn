using BMH.Core.Services;
using BMH.Core.Domain.Enums;

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

    [Fact]
    public void CreateBundesliga_Should_Create_Squads_For_All_Clubs()
    {
        var generator = new LeagueGenerator();

        var league = generator.CreateBundesliga();

        foreach (var club in league.Clubs)
        {
            Assert.Equal(20, club.Players.Count);
            Assert.Equal(2, club.Players.Count(p => p.Position == Position.Goalkeeper));
            Assert.Equal(7, club.Players.Count(p => p.Position == Position.Defender));
            Assert.Equal(7, club.Players.Count(p => p.Position == Position.Midfielder));
            Assert.Equal(4, club.Players.Count(p => p.Position == Position.Striker));
        }
    }

    [Fact]
    public void CreateBundesliga_Should_Generate_Stronger_Squads_For_Higher_Reputation_Clubs()
    {
        var generator = new LeagueGenerator(
            new PlayerGenerator(
                new PlayerFactory(new Random(1))));

        var league = generator.CreateBundesliga();
        var bayern = league.Clubs.Single(c => c.ShortName == "FCB");
        var stPauli = league.Clubs.Single(c => c.ShortName == "STP");

        Assert.True(
            bayern.Players.Average(p => p.Overall) >
            stPauli.Players.Average(p => p.Overall));
    }
}
