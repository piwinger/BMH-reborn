namespace BMH.Core.Domain.Entities;

public sealed class GameClock
{
    public int Season { get; private set; }

    public int MatchDay { get; private set; } = 1;

    public void AdvanceMatchDay(int maxMatchDays)
    {
        MatchDay++;

        if (MatchDay > maxMatchDays)
        {
            Season++;
            MatchDay = 1;
        }
    }
}