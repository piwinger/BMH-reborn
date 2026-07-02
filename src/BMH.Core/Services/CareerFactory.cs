using BMH.Core.Domain.Entities;

namespace BMH.Core.Services;

public sealed class CareerFactory
{
    public Career Create(
        string managerName,
        League league,
        Club club)
    {
        var world = new GameWorld();

        world.AddLeague(league);

        var manager = new Manager(managerName, club);

        return new Career(
            manager,
            world,
            new GameClock());
    }
}