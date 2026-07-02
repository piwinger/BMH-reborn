using BMH.Core.Services;

namespace BMH.Tests.Services;

public class RandomNameProviderTests
{
    [Fact]
    public void CreateName_Should_Return_Name_From_Configured_Lists()
    {
        var provider = new RandomNameProvider(
            ["Andreas"],
            ["Müller"],
            new Random(1));

        var name = provider.CreateName();

        Assert.Equal("Andreas", name.FirstName);
        Assert.Equal("Müller", name.LastName);
    }

    [Fact]
    public void Load_Should_Read_Names_From_Database_Files()
    {
        var provider = RandomNameProvider.Load(
            GetDatabasePath("firstnames_de.txt"),
            GetDatabasePath("lastnames_de.txt"));

        var name = provider.CreateName();

        Assert.False(string.IsNullOrWhiteSpace(name.FirstName));
        Assert.False(string.IsNullOrWhiteSpace(name.LastName));
        Assert.NotEqual("Player", name.FirstName);
    }

    private static string GetDatabasePath(string fileName)
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);

        while (directory is not null)
        {
            var path = Path.Combine(
                directory.FullName,
                "assets",
                "databases",
                "bundesliga1994",
                fileName);

            if (File.Exists(path))
                return path;

            directory = directory.Parent;
        }

        throw new FileNotFoundException($"Could not find database file '{fileName}'.");
    }
}
