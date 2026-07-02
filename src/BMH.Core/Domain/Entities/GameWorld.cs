namespace BMH.Core.Domain.Entities;

public sealed class GameWorld
{
    private readonly List<League> _leagues = new();

    public IReadOnlyList<League> Leagues => _leagues;

    public void AddLeague(League league)
    {
        _leagues.Add(league);
    }

    public League GetLeague(string name)
    {
        return _leagues.Single(l => l.Name == name);
    }
}