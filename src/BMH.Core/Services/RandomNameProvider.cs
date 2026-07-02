namespace BMH.Core.Services;

public sealed class RandomNameProvider : INameProvider
{
    private readonly IReadOnlyList<string> _firstNames;
    private readonly IReadOnlyList<string> _lastNames;
    private readonly Random _random;

    public RandomNameProvider(
        IReadOnlyList<string> firstNames,
        IReadOnlyList<string> lastNames)
        : this(firstNames, lastNames, new Random())
    {
    }

    public RandomNameProvider(
        IReadOnlyList<string> firstNames,
        IReadOnlyList<string> lastNames,
        Random random)
    {
        if (firstNames.Count == 0)
            throw new ArgumentException("At least one first name is required.", nameof(firstNames));

        if (lastNames.Count == 0)
            throw new ArgumentException("At least one last name is required.", nameof(lastNames));

        _firstNames = firstNames;
        _lastNames = lastNames;
        _random = random;
    }

    public static RandomNameProvider Load(
        string firstNamesPath,
        string lastNamesPath)
    {
        return new RandomNameProvider(
            LoadNames(firstNamesPath),
            LoadNames(lastNamesPath));
    }

    public (string FirstName, string LastName) CreateName()
    {
        return (
            _firstNames[_random.Next(_firstNames.Count)],
            _lastNames[_random.Next(_lastNames.Count)]);
    }

    private static IReadOnlyList<string> LoadNames(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("Name database file was not found.", path);

        var names = File.ReadAllLines(path)
            .Select(line => line.Trim())
            .Where(line => line.Length > 0)
            .Distinct()
            .ToList();

        if (names.Count == 0)
            throw new InvalidOperationException($"Name database file '{path}' is empty.");

        return names;
    }
}
