namespace BMH.Core.Domain.Entities;

public sealed class Club
{
    public Guid Id { get; } = Guid.NewGuid();

    public string Name { get; private set; }

    public string ShortName { get; private set; }

    public string City { get; private set; }

    public decimal Budget { get; private set; }

    public int Reputation { get; private set; }

    public Club(
        string name,
        string shortName,
        string city,
        decimal budget,
        int reputation)
    {
        Name = name;
        ShortName = shortName;
        City = city;
        Budget = budget;
        Reputation = reputation;
    }

    public override string ToString()
        => $"{Name} ({City})";
}