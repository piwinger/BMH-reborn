using BMH.Core.Domain.Entities;
using BMH.Core.Services;

namespace BMH.Tests.Services;

public class PlayerGeneratorTests
{
    [Fact]
    public void GenerateSquad_Should_Use_NameProvider()
    {
        var club = new Club("Test Club", "TST", "Teststadt", 1_000_000m, 70);
        var generator = new PlayerGenerator(
            new PlayerFactory(new Random(1)),
            new RandomNameProvider(["Andreas"], ["Müller"], new Random(1)));

        generator.GenerateSquad(club);

        Assert.All(club.Players, player =>
        {
            Assert.Equal("Andreas", player.FirstName);
            Assert.Equal("Müller", player.LastName);
        });
    }
}
