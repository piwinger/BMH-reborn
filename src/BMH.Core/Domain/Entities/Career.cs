namespace BMH.Core.Domain.Entities;

public sealed class Career
{
    public Career(
        Manager manager,
        GameWorld world,
        GameClock clock)
    {
        Manager = manager;
        World = world;
        Clock = clock;
    }

    public Manager Manager { get; }

    public GameWorld World { get; }

    public GameClock Clock { get; }
}