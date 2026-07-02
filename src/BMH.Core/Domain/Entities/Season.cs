namespace BMH.Core.Domain.Entities;

public sealed class Season
{
    private readonly List<Fixture> _fixtures = new();

    public IReadOnlyList<Fixture> Fixtures => _fixtures;

    public int CurrentMatchDay { get; private set; } = 1;

    public void AddFixture(Fixture fixture)
    {
        _fixtures.Add(fixture);
    }

    public IReadOnlyList<Fixture> GetMatchDay(int matchDay)
    {
        return _fixtures
            .Where(f => f.MatchDay == matchDay)
            .ToList();
    }

    public void NextMatchDay()
    {
        CurrentMatchDay++;
    }
}