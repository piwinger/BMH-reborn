using BMH.Core.Domain.Enums;
using BMH.Core.Domain.ValueObjects;

namespace BMH.Core.Domain.Entities;

public sealed class Player
{
    public Guid Id { get; } = Guid.NewGuid();

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public Position Position { get; private set; }

    public int Age { get; private set; }

    public PlayerAttributes Attributes { get; }

    public int Potential { get; private set; }

    public int Fitness { get; private set; } = 100;

    public bool IsInjured => Fitness < 100;

    public int Morale { get; private set; } = 100;

    public decimal Salary { get; private set; }

    public decimal MarketValue { get; private set; }

    public Player(
        string firstName,
        string lastName,
        Position position,
        int age,
        PlayerAttributes attributes,
        int potential)
    {
        FirstName = firstName;
        LastName = lastName;
        Position = position;
        Age = age;
        Attributes = attributes;
        Potential = potential;
    }

    public string FullName => $"{FirstName} {LastName}";

    public int Overall => Attributes.Overall;

    public override string ToString() => $"{FullName} ({Overall})";
    public void ImproveFitness(int amount)
    {
        Fitness = Math.Min(100, Fitness + amount);
    }

    public void ReduceFitness(int amount)
    {
        Fitness = Math.Max(0, Fitness - amount);
    }
}