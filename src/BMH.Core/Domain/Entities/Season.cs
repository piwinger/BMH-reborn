namespace BMH.Core.Domain.Entities;

public sealed class Season
{
    private readonly List<Fixture> _fixtures = new();

    public IReadOnlyList<Fixture> Fixtures => _fixtures;

    public int CurrentMatchDay { get; private set; } = 1;

    public int LastMatchDay => _fixtures.Count == 0
        ? 0
        : _fixtures.Max(f => f.MatchDay);

    public bool IsCompleted => LastMatchDay > 0 &&
        _results.Count == _fixtures.Count;

    private readonly List<MatchResult> _results = new();

    public IReadOnlyList<MatchResult> Results => _results;

    public void AddResult(MatchResult result)
    {
        if (!_fixtures.Contains(result.Fixture))
            throw new InvalidOperationException("Fixture is not part of this season.");

        if (_results.Any(r => r.Fixture == result.Fixture))
            throw new InvalidOperationException("Fixture already has a result.");

        _results.Add(result);
    }

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
        if (CurrentMatchDay <= LastMatchDay)
            CurrentMatchDay++;
    }
}
