public sealed class GameDate
{
    public int Season { get; private set; }

    public int MatchDay { get; private set; }

    public void NextMatchDay()
    {
        MatchDay++;

        if (MatchDay > 34)
        {
            Season++;
            MatchDay = 1;
        }
    }
}