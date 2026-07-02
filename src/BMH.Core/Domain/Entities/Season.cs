namespace BMH.Core.Domain.Entities;

public sealed class Season
{
    private readonly List<Fixture> _fixtures = new();

    public IReadOnlyList<Fixture> Fixtures => _fixtures;

    public void AddFixture(Fixture fixture)
    {
        _fixtures.Add(fixture);
    }
}