namespace BMH.Core.Domain.Entities;

public sealed class Manager
{
    public Manager(string name, Club club)
    {
        Name = name;
        Club = club;
    }

    public string Name { get; }

    public Club Club { get; private set; }

    public void ChangeClub(Club club)
    {
        Club = club;
    }
}