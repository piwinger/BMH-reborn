using BMH.Core.Domain.Enums;

namespace BMH.Core.Domain.Entities;

public sealed class Lineup
{
    private readonly List<LineupPosition> _players = new();

    public FormationType Formation { get; }

    public IReadOnlyList<LineupPosition> Players => _players;

    public Lineup(FormationType formation)
    {
        Formation = formation;
    }

    public void Add(Player player, PlayerRole role)
    {
        _players.Add(new LineupPosition(player, role));
    }
}