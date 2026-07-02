using BMH.Core.Services;

var league = new LeagueGenerator().CreateBundesliga();

new FixtureGenerator().Generate(league);

new SeasonSimulator().PlayCurrentMatchDay(league);

var table = new TableCalculator().Calculate(league);

Console.WriteLine("Tabelle nach dem 1. Spieltag");
Console.WriteLine();

foreach (var team in table)
{
    Console.WriteLine(
        $"{team.Club.Name,-30} {team.MatchesPlayed,2} {team.Wins,2} {team.Draws,2} {team.Losses,2} {team.GoalsFor,2}:{team.GoalsAgainst,-2} {team.GoalDifference,3} {team.Points,3} Pkt.");
}
