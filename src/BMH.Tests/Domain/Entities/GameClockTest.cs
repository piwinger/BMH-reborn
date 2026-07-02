
using BMH.Core.Domain.Entities;

public class GameClockTest
{
    [Fact]
    public void Should_Advance_Matchday()
    {
        var clock = new GameClock();

        clock.AdvanceMatchDay(34);

        Assert.Equal(2, clock.MatchDay);
    }
}