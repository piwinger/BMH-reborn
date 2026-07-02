using BMH.Core.Services;

var league = new LeagueGenerator().CreateBundesliga();

new FixtureGenerator().Generate(league);

foreach (var fixture in league.Season.Fixtures
                                .Where(f => f.MatchDay == 1))
{
    Console.WriteLine(fixture);
}