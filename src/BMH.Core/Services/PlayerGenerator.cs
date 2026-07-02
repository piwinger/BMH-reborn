using BMH.Core.Domain.Entities;
using BMH.Core.Domain.Enums;

namespace BMH.Core.Services;

public sealed class PlayerGenerator
{
    private readonly PlayerFactory _factory = new();

    public void GenerateSquad(Club club)
    {
        AddPlayers(club, Position.Goalkeeper,2);
        AddPlayers(club, Position.Defender,7);
        AddPlayers(club, Position.Midfielder,7);
        AddPlayers(club, Position.Striker,4);
    }

    private void AddPlayers(
        Club club,
        Position position,
        int amount)
    {
        for(int i=0;i<amount;i++)
        {
            club.AddPlayer(
                _factory.Create(
                    "Player",
                    $"{position}_{i+1}",
                    position,
                    club.Reputation));
        }
    }
}