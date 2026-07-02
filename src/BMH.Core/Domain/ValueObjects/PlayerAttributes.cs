namespace BMH.Core.Domain.ValueObjects;

public sealed class PlayerAttributes
{
    public int Technical { get; }

    public int Mental { get; }

    public int Physical { get; }

    public PlayerAttributes(
        int technical,
        int mental,
        int physical)
    {
        Technical = technical;
        Mental = mental;
        Physical = physical;
    }

    public int Overall =>
        (int)Math.Round(
            (Technical + Mental + Physical) / 3.0);
}