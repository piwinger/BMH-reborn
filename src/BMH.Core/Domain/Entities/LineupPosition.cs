using BMH.Core.Domain.Enums;

namespace BMH.Core.Domain.Entities;

public sealed class LineupPosition
{
    public LineupPosition(Player player, PlayerRole role)
    {
        Player = player;
        Role = role;
    }

    public Player Player { get; }

    public PlayerRole Role { get; }
}