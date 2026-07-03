namespace BMH.Core.Domain.ValueObjects;

public sealed record Formation(
    string Name,
    int Defenders,
    int Midfielders,
    int Forwards)
{
    public static readonly Formation FourFourTwo =
        new("4-4-2", 4, 4, 2);

    public static readonly Formation FourThreeThree =
        new("4-3-3", 4, 3, 3);

    public static readonly Formation ThreeFiveTwo =
        new("3-5-2", 3, 5, 2);

    public static readonly Formation FiveThreeTwo =
        new("5-3-2", 5, 3, 2);
}