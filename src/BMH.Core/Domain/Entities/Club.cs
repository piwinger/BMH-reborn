using BMH.Core.Domain.ValueObjects;

namespace BMH.Core.Domain.Entities;

public sealed class Club
{
    private readonly List<Player> _players = new();

    public Guid Id { get; } = Guid.NewGuid();

    public string Name { get; }

    public string ShortName { get; }

    public string City { get; }

    public int Reputation { get; }

    public IReadOnlyList<Player> Players => _players;

    public TeamSelection? CurrentLineup { get; private set; }

    public decimal Balance { get; private set; }

    public string StadiumName { get; private set; }

    public int StadiumCapacity { get; private set; }

    public Formation PreferredFormation { get; private set; }

    public Club(
        string name,
        string shortName,
        string city,
        decimal balance,
        int reputation,
        string stadiumName = "Stadion",
        int stadiumCapacity = 50000,
        Formation? preferredFormation = null)
    {
        Name = name;
        ShortName = shortName;
        City = city;
        Balance = balance;
        Reputation = reputation;
        StadiumName = stadiumName;
        StadiumCapacity = stadiumCapacity;
        PreferredFormation = preferredFormation ?? Formation.FourFourTwo;
    }

    public void AddPlayer(Player player)
    {
        _players.Add(player);
    }

    public decimal Spend(decimal amount)
    {
        if (amount > Balance)
            throw new InvalidOperationException("Balance überschritten.");

        Balance -= amount;
        return Balance;
    }

    public void Earn(decimal amount)
    {
        Balance += amount;
    }

    public void SetLineup(TeamSelection lineup)
    {
        CurrentLineup = lineup;
    }
}