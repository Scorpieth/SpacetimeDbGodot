using SpacetimeDB.Types;

namespace GodotClient.SpacetimeDb;

public static class WorldCallbacks
{
    public static DbConnection RegisterWorldCallbacks(this DbConnection connection)
    {
        connection.Reducers.OnEnterWorld += OnEnterWorld;
        
        return connection;
    }

    private static void OnEnterWorld(ReducerEventContext ctx)
    {
        throw new System.NotImplementedException();
    }
}