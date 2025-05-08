using SpacetimeDB;
using StdbModule.domain;

public static partial class Module
{
    [Reducer(ReducerKind.Init)]
    public static void Init(ReducerContext ctx)
    {
        Log.Info("Initializing...");

        ctx.Db.Worlds.Insert(new ServerWorldConfig(0, 1000));
    }
}