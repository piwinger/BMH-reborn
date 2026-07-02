namespace BMH.Core.Domain.Entities;

public sealed class Fixture
{
    public Fixture(
        int matchDay,
        Club homeClub,
        Club awayClub)
    {
        MatchDay = matchDay;
        HomeClub = homeClub;
        AwayClub = awayClub;
    }

    public int MatchDay { get; }

    public Club HomeClub { get; }

    public Club AwayClub { get; }

    public override string ToString()
        => $"{HomeClub.Name} - {AwayClub.Name}";
}