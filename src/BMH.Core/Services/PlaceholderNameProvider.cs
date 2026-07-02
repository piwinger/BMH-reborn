namespace BMH.Core.Services;

public sealed class PlaceholderNameProvider : INameProvider
{
    private int _nextNumber = 1;

    public (string FirstName, string LastName) CreateName()
    {
        return ("Player", $"Generated_{_nextNumber++}");
    }
}
