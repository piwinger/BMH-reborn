namespace BMH.Core.Domain.Entities;

public sealed class League
{
    private readonly List<Club> _clubs = new();

    public string Name { get; }

    public int Season { get; }

    public IReadOnlyList<Club> Clubs => _clubs;

    public League(string name, int season)
    {
        Name = name;
        Season = season;
    }

    public void AddClub(Club club)
    {
        _clubs.Add(club);
    }
}