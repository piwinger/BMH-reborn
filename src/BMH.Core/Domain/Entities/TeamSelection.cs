using BMH.Core.Domain.Entities;

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

}