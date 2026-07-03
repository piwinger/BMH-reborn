
using BMH.Core.Domain.Enums;
using BMH.Tests.Builders;

public class PlayerTest
{
    [Fact]
    public void Rating_On_Natural_Position_Should_Be_Overall()
    {
        var player = new PlayerBuilder()
            .AsForward()
            .WithOverall(84)
            .Build();

        Assert.Equal(
            player.Overall,
            player.GetRatingFor(Position.Striker));
    }

    [Fact]
    public void Rating_On_Other_Position_Should_Be_Lower()
    {
        var player = new PlayerBuilder()
            .AsForward()
            .WithOverall(84)
            .Build();

        Assert.True(
            player.GetRatingFor(Position.Defender)
            <
            player.GetRatingFor(Position.Striker));
    }

    [Fact]
    public void Rating_Should_Never_Be_Negative()
    {
        var player = new PlayerBuilder()
            .AsForward()
            .WithOverall(0)
            .Build();

        Assert.True(player.GetRatingFor(Position.Goalkeeper) >= 0);
    }
}