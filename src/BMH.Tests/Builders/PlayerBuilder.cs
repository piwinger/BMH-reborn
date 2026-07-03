using BMH.Core.Domain.Entities;
using BMH.Core.Domain.Enums;
using BMH.Core.Domain.ValueObjects;

namespace BMH.Tests.Builders;

public sealed class PlayerBuilder
{
    private string _firstName = "Max";
    private string _lastName = "Mustermann";
    private Position _position = Position.Midfielder;
    private int _age = 24;

    private int _technical = 70;
    private int _mental = 70;
    private int _physical = 70;

    private int _potential = 80;

    public PlayerBuilder WithName(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
        return this;
    }

    public PlayerBuilder WithAge(int age)
    {
        _age = age;
        return this;
    }

    public PlayerBuilder AsGoalkeeper()
    {
        _position = Position.Goalkeeper;
        return this;
    }

    public PlayerBuilder AsDefender()
    {
        _position = Position.Defender;
        return this;
    }

    public PlayerBuilder AsMidfielder()
    {
        _position = Position.Midfielder;
        return this;
    }

    public PlayerBuilder AsForward()
    {
        _position = Position.Striker;
        return this;
    }

    public PlayerBuilder WithTechnical(int value)
    {
        _technical = value;
        return this;
    }

    public PlayerBuilder WithMental(int value)
    {
        _mental = value;
        return this;
    }

    public PlayerBuilder WithPhysical(int value)
    {
        _physical = value;
        return this;
    }

    public PlayerBuilder WithOverall(int overall)
    {
        _technical = overall;
        _mental = overall;
        _physical = overall;
        return this;
    }

    public PlayerBuilder WithPotential(int potential)
    {
        _potential = potential;
        return this;
    }

    public Player Build()
    {
        return new Player(
            _firstName,
            _lastName,
            _position,
            _age,
            new PlayerAttributes(
                _technical,
                _mental,
                _physical),
            _potential);
    }
}