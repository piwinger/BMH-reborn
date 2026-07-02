namespace BMH.Core.Domain.Entities;

public sealed class League
{
    private readonly List<Club> _clubs = new();

    public string Name { get; }

    public Season Season { get; }

    public IReadOnlyList<Club> Clubs => _clubs;

    public League(string name)
    {
        Name = name;
        Season = new Season();
    }

    public void AddClub(Club club)
    {
        _clubs.Add(club);
    }
}