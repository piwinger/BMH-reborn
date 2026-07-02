using BMH.Core.Domain.Entities;
using BMH.Core.Domain.Enums;

namespace BMH.Core.Services;

public sealed class PlayerGenerator
{
    private readonly PlayerFactory _factory;
    private readonly INameProvider _nameProvider;

    public PlayerGenerator()
        : this(new PlayerFactory(), new PlaceholderNameProvider())
    {
    }

    public PlayerGenerator(PlayerFactory factory)
        : this(factory, new PlaceholderNameProvider())
    {
    }

    public PlayerGenerator(
        PlayerFactory factory,
        INameProvider nameProvider)
    {
        _factory = factory;
        _nameProvider = nameProvider;
    }

    public void GenerateSquad(Club club)
    {
        AddPlayers(club, Position.Goalkeeper, 2);
        AddPlayers(club, Position.Defender, 7);
        AddPlayers(club, Position.Midfielder, 7);
        AddPlayers(club, Position.Striker, 4);
    }

    private void AddPlayers(
        Club club,
        Position position,
        int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var name = _nameProvider.CreateName();

            club.AddPlayer(
                _factory.Create(
                    name.FirstName,
                    name.LastName,
                    position,
                    club.Reputation));
        }
    }
}
