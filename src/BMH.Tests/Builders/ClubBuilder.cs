using BMH.Core.Domain.Entities;
using BMH.Core.Domain.ValueObjects;

namespace BMH.Tests.Builders;

public sealed class ClubBuilder
{
    private readonly Club _club;

    public ClubBuilder()
    {
        _club = new Club(
            name: "Test FC",
            shortName: "TFC",
            city: "Test City",
            balance: 1_000_000m,
            stadiumName: "Test Arena",
            stadiumCapacity: 20000,
            reputation: 50,
            preferredFormation: Formation.FourFourTwo);
    }

    public ClubBuilder WithPlayer(Player player)
    {
        _club.AddPlayer(player);
        return this;
    }

    public Club Build() => _club;
}