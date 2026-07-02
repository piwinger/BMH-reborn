using BMH.Core.Services;

var league = new LeagueGenerator().CreateBundesliga();

new FixtureGenerator().Generate(league);

new SeasonSimulator().PlayRemainingSeason(league);

var table = new TableCalculator().Calculate(league);

Console.WriteLine("Abschlusstabelle Bundesliga");
Console.WriteLine();

for (int i = 0; i < table.Count; i++)
{
    var team = table[i];
    var note = i switch
    {
        0 => " Meister",
        >= 15 => " Abstieg",
        _ => string.Empty
    };

    Console.WriteLine(
        $"{i + 1,2}. {team.Club.Name,-30} {team.MatchesPlayed,2} {team.Wins,2} {team.Draws,2} {team.Losses,2} {team.GoalsFor,3}:{team.GoalsAgainst,-3} {team.GoalDifference,4} {team.Points,3} Pkt.{note}");
}
