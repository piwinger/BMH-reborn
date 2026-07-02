namespace BMH.Core.Domain.Entities;

public sealed class Club
{
    private readonly List<Player> _players = new();

    public Guid Id { get; } = Guid.NewGuid();

    public string Name { get; }

    public string ShortName { get; }

    public string City { get; }

    public decimal Budget { get; private set; }

    public int Reputation { get; }

    public IReadOnlyList<Player> Players => _players;

    public IReadOnlyList<Player> Squad => _players;

    public Lineup? CurrentLineup { get; private set; }

    public decimal Balance { get; private set; }

    public string StadiumName { get; private set; }

    public int StadiumCapacity { get; private set; }

    public Formation PreferredFormation { get; private set; }

    public Club(
        string name,
        string shortName,
        string city,
        decimal budget,
        int reputation,
        string stadiumName = "Stadion",
        int stadiumCapacity = 50000,
        Formation? preferredFormation = null)
    {
        Name = name;
        ShortName = shortName;
        City = city;
        Budget = budget;
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
        if (amount > Budget)
            throw new InvalidOperationException("Budget überschritten.");

        Budget -= amount;
        return Budget;
    }

    public void Earn(decimal amount)
    {
        Budget += amount;
    }

    public void SetLineup(Lineup lineup)
    {
        CurrentLineup = lineup;
    }
}