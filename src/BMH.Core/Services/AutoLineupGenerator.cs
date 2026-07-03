using BMH.Core.Domain.Entities;
using BMH.Core.Domain.Enums;

namespace BMH.Core.Services;

public sealed class AutoLineupGenerator
{
    public TeamSelection Create(Club club)
    {
        var selection = new TeamSelection(club.PreferredFormation);

        AddBest(selection, club, Position.Goalkeeper, 1);
        AddBest(selection, club, Position.Defender, 4);
        AddBest(selection, club, Position.Midfielder, 4);
        AddBest(selection, club, Position.Striker, 2);

        return selection;
    }

    private static void AddBest(
        TeamSelection selection,
        Club club,
        Position position,
        int amount)
    {
        var players = club.Players
            .Where(p => p.Position == position)
            .OrderByDescending(p => p.GetRatingFor(position))
            .Take(amount);

        foreach (var player in players)
        {
            selection.AddStarter(player);
        }
    }
}