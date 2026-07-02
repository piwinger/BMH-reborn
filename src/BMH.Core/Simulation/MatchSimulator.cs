using BMH.Core.Domain.Entities;

namespace BMH.Core.Services;

public sealed class MatchSimulator
{
    private readonly Random _random = new();

    public MatchResult Simulate(Fixture fixture)
    {
        return new MatchResult(
            fixture,
            _random.Next(0, 6),
            _random.Next(0, 6));
    }
}