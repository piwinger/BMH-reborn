using BMH.Core.Domain.Entities;

public class ClubTests
{
    [Fact]
    public void Club_Starts_With_Empty_Player_List()
    {
        var club = new Club(
            "Borussia Dortmund",
            "BVB",
            "Dortmund",
            42_000_000,
            90);

        Assert.Empty(club.Players);
    }
}