using BMH.Core.Domain.Entities;

namespace BMH.Core.Services;

public sealed class SeasonSimulator
{
    private readonly MatchSimulator _simulator;

    public SeasonSimulator()
        : this(new MatchSimulator())
    {
    }

    public SeasonSimulator(MatchSimulator simulator)
    {
        _simulator = simulator;
    }

    public void PlayRemainingSeason(League league)
    {
        while (!league.Season.IsCompleted)
        {
            PlayCurrentMatchDay(league);
        }
    }

    public void PlayCurrentMatchDay(League league)
    {
        PlayMatchDay(league, league.Season.CurrentMatchDay);
        league.Season.NextMatchDay();
    }

    public void PlayMatchDay(League league, int matchDay)
    {
        foreach (var fixture in league.Season.GetMatchDay(matchDay))
        {
            league.Season.AddResult(
                _simulator.Simulate(fixture));
        }
    }
}
