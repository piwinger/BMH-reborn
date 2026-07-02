public sealed class Formation
{
    public string Name { get; }

    public int Defenders { get; }

    public int Midfielders { get; }

    public int Forwards { get; }

    public Formation(
        string name,
        int defenders,
        int midfielders,
        int forwards)
    {
        Name = name;
        Defenders = defenders;
        Midfielders = midfielders;
        Forwards = forwards;
    }

    public static Formation FourFourTwo =>
        new("4-4-2",4,4,2);

    public static Formation FourThreeThree =>
        new("4-3-3",4,3,3);

    public static Formation ThreeFiveTwo =>
        new("3-5-2",3,5,2);
}