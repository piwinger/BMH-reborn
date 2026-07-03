using BMH.Core.Domain.Entities;
using BMH.Core.Domain.ValueObjects;

public sealed class TeamSelection
{
    private readonly List<Player> _startingEleven = new();
    private readonly List<Player> _bench = new();

    public Formation Formation { get; }

    public IReadOnlyList<Player> StartingEleven => _startingEleven;

    public IReadOnlyList<Player> Bench => _bench;

    public TeamSelection(Formation formation)
    {
        Formation = formation;
    }

    public void AddStarter(Player player)
    {
        if (_startingEleven.Contains(player))
            throw new InvalidOperationException("Player already selected.");

        if (_startingEleven.Count >= 11)
            throw new InvalidOperationException("Starting eleven is full.");

        _startingEleven.Add(player);
    }

    public void AddSubstitute(Player player)
    {
        if (_bench.Contains(player))
            throw new InvalidOperationException("Player already on bench.");

        _bench.Add(player);
    }

}