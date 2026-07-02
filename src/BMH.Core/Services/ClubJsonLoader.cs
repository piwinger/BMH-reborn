using System.Text.Json;
using BMH.Core.Domain.Entities;

namespace BMH.Core.Services;

public sealed class ClubJsonLoader
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public IReadOnlyList<Club> Load(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Club database file was not found.", filePath);

        var json = File.ReadAllText(filePath);
        var records = JsonSerializer.Deserialize<IReadOnlyList<ClubRecord>>(json, Options)
            ?? throw new InvalidOperationException("Club database is empty or invalid.");

        return records
            .Select(record => new Club(
                record.Name,
                record.ShortName,
                record.City,
                record.Budget,
                record.Reputation))
            .ToList();
    }

    private sealed record ClubRecord(
        string Name,
        string ShortName,
        string City,
        decimal Budget,
        int Reputation);
}
