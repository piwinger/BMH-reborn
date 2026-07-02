using BMH.Core.Services;

var clubsPath = FindDatabaseFile("bundesliga1994", "clubs.json");
var firstNamesPath = FindDatabaseFile("bundesliga1994", "firstnames_de.txt");
var lastNamesPath = FindDatabaseFile("bundesliga1994", "lastnames_de.txt");

var clubs = new ClubJsonLoader().Load(clubsPath);
var nameProvider = RandomNameProvider.Load(firstNamesPath, lastNamesPath);
var playerGenerator = new PlayerGenerator(new PlayerFactory(), nameProvider);
var league = new LeagueGenerator(playerGenerator).CreateBundesliga(clubs);

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

static string FindDatabaseFile(string databaseName, string fileName)
{
    var directory = new DirectoryInfo(Environment.CurrentDirectory);

    while (directory is not null)
    {
        var path = Path.Combine(
            directory.FullName,
            "assets",
            "databases",
            databaseName,
            fileName);

        if (File.Exists(path))
            return path;

        directory = directory.Parent;
    }

    throw new FileNotFoundException(
        $"Could not find database file '{fileName}' for '{databaseName}'.");
}
