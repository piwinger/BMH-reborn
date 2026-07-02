using BMH.Core.Domain.Entities;

namespace BMH.Core.Services;

public sealed class TeamStrengthCalculator
{
    public double Calculate(Club club)
    {
        var players = club.Players; // ggf. Squad, je nach aktuellem Club.cs

        if (!players.Any())
            return 0;

        return players.Average(p => p.Overall);
    }
}