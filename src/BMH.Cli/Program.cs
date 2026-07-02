using BMH.Core.Services;

var generator = new LeagueGenerator();

var league = generator.CreateBundesliga();

Console.WriteLine(league.Name);
Console.WriteLine();

foreach (var club in league.Clubs)
{
    Console.WriteLine($"{club.Name} ({club.City})");
}