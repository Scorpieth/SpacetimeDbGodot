using SpacetimeDB;
using StdbModule.domain;
using StdbModule.Features.Players;

public static partial class Module
{
    [Reducer(ReducerKind.Init)]
    public static void Init(ReducerContext ctx)
    {
        Log.Info("Initializing...");

        ctx.Db.Worlds.Insert(new ServerWorldConfig(0, 1000));
        ctx.Db.MovePlayersSchedules.Insert(new Movement.MovePlayersSchedule()
        {
            ScheduleAt = new ScheduleAt.Time(ctx.Timestamp + new TimeDuration(1_000_000)),
        });
    }
}