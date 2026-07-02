
using BMH.Core.Services;

public class CareerFactoryTest
{

    [Fact]
    public void Should_Create_Career()
    {
        var league = new LeagueGenerator().CreateBundesliga();

        var club = league.Clubs.First();

        var career = new CareerFactory()
            .Create("Stefan", league, club);

        Assert.Equal("Stefan", career.Manager.Name);
        Assert.Equal(club, career.Manager.Club);
        Assert.Single(career.World.Leagues);
    }
}