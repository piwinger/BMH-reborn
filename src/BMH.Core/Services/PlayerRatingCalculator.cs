using BMH.Core.Domain.Entities;
using BMH.Core.Domain.Enums;

public interface IPlayerRatingCalculator
{
    double Calculate(Player player, Position position);
}

public sealed class PlayerRatingCalculator : IPlayerRatingCalculator
{
    public double Calculate(Player player, Position position)
    {
        var overall = player.Overall;

        return player.Position == position
            ? overall
            : overall * 0.65;
    }
}