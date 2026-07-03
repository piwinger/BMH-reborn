using BMH.Core.Domain.Enums;
using BMH.Core.Services;
using BMH.Tests.Builders;

public class AutoLineupGeneratorTest
{
    [Fact]
    public void Should_Create_Eleven_Player_Lineup()
    {
        var club = new ClubBuilder()
            .WithPlayer(new PlayerBuilder().AsGoalkeeper().WithOverall(82).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(79).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(77).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(76).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(75).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(81).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(80).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(79).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(78).Build())
            .WithPlayer(new PlayerBuilder().AsForward().WithOverall(84).Build())
            .WithPlayer(new PlayerBuilder().AsForward().WithOverall(83).Build())
            .Build();

        var lineup = new AutoLineupGenerator().Create(club);

        Assert.Equal(11, lineup.StartingEleven.Count);
    }

    [Fact]
    public void No_Player_Should_Appear_Twice()
    {
        var club = new ClubBuilder()
            .WithPlayer(new PlayerBuilder().AsGoalkeeper().WithOverall(82).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(79).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(77).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(76).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(75).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(81).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(80).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(79).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(78).Build())
            .WithPlayer(new PlayerBuilder().AsForward().WithOverall(84).Build())
            .WithPlayer(new PlayerBuilder().AsForward().WithOverall(83).Build())
            .Build();

        var lineup = new AutoLineupGenerator().Create(club);

        Assert.Equal(
            lineup.StartingEleven.Count,
            lineup.StartingEleven.Distinct().Count());
    }

    [Fact]
    public void Every_Player_Should_Belong_To_Club()
    {
        var club = new ClubBuilder()
            .WithPlayer(new PlayerBuilder().AsGoalkeeper().WithOverall(82).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(79).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(77).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(76).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(75).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(81).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(80).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(79).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(78).Build())
            .WithPlayer(new PlayerBuilder().AsForward().WithOverall(84).Build())
            .WithPlayer(new PlayerBuilder().AsForward().WithOverall(83).Build())
            .Build();

        var lineup = new AutoLineupGenerator().Create(club);

        Assert.All(
            lineup.StartingEleven,
            p => Assert.Contains(p, club.Players));
    }

    [Fact]
    public void Goalkeeper_Should_Be_Selected()
    {
        var club = new ClubBuilder()
            .WithPlayer(new PlayerBuilder().AsGoalkeeper().WithOverall(82).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(79).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(77).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(76).Build())
            .WithPlayer(new PlayerBuilder().AsDefender().WithOverall(75).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(81).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(80).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(79).Build())
            .WithPlayer(new PlayerBuilder().AsMidfielder().WithOverall(78).Build())
            .WithPlayer(new PlayerBuilder().AsForward().WithOverall(84).Build())
            .WithPlayer(new PlayerBuilder().AsForward().WithOverall(83).Build())
            .Build();

        var lineup = new AutoLineupGenerator().Create(club);
        Assert.Single(
            lineup.StartingEleven,
            p => p.Position == Position.Goalkeeper);
    }
}