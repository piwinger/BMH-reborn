using BMH.Core.Domain.Entities;
using BMH.Core.Domain.Enums;
using BMH.Core.Domain.ValueObjects;

namespace BMH.Core.Services;

public sealed class PlayerFactory
{
    private readonly Random _random = new();

    public Player Create(
        string firstName,
        string lastName,
        Position position,
        int reputation)
    {
        int age = RandomAge();

        int overall = GenerateOverall(reputation);

        int potential = Math.Max(overall,
            overall + _random.Next(0, 15));

        var attributes = CreateAttributes(overall);

        return new Player(
            firstName,
            lastName,
            position,
            age,
            attributes,
            potential);
    }

    private int RandomAge()
    {
        int roll = _random.Next(100);

        return roll switch
        {
            < 10 => _random.Next(17,20),
            < 35 => _random.Next(20,24),
            < 75 => _random.Next(24,29),
            < 95 => _random.Next(29,33),
            _ => _random.Next(33,37)
        };
    }

    private int GenerateOverall(int reputation)
    {
        int value = reputation + _random.Next(-12,13);

        return Math.Clamp(value,40,99);
    }

    private PlayerAttributes CreateAttributes(int overall)
    {
        int tech = overall + _random.Next(-5,6);
        int mental = overall + _random.Next(-5,6);
        int physical = overall + _random.Next(-5,6);

        return new PlayerAttributes(
            Math.Clamp(tech,1,99),
            Math.Clamp(mental,1,99),
            Math.Clamp(physical,1,99));
    }
}