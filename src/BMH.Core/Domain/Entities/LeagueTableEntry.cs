namespace BMH.Core.Domain.Entities;

public sealed class LeagueTableEntry
{
    public LeagueTableEntry(Club club)
    {
        Club = club;
    }

    public Club Club { get; }

    public int MatchesPlayed { get; private set; }
    public int Wins { get; private set; }
    public int Draws { get; private set; }
    public int Losses { get; private set; }

    public int GoalsFor { get; private set; }
    public int GoalsAgainst { get; private set; }

    public int GoalDifference => GoalsFor - GoalsAgainst;

    public int Points { get; private set; }

    public void AddMatch(int goalsFor, int goalsAgainst)
    {
        MatchesPlayed++;
        GoalsFor += goalsFor;
        GoalsAgainst += goalsAgainst;

        if (goalsFor > goalsAgainst)
        {
            Wins++;
            Points += 3;
        }
        else if (goalsFor == goalsAgainst)
        {
            Draws++;
            Points++;
        }
        else
        {
            Losses++;
        }
    }
}