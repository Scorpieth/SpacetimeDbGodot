using Godot;
using GodotClient.Autoload;
using SpacetimeDB.Types;

namespace GodotClient.SpacetimeDb;

public static class EntityCallbacks
{
    public static DbConnection RegisterEntityCallbacks(this DbConnection connection)
    {
        connection.Db.Players.OnInsert += OnInsertPlayer;
        connection.Db.Entities.OnUpdate += OnEntitiesUpdate;
        return connection;
    }

    private static void OnEntitiesUpdate(EventContext context, Entity oldrow, Entity newrow)
    {
        GD.Print("Entity updated");
        var playerId = context.Db.Players.EntityId.Find(newrow.EntityId)?.UserId;
        if (!playerId.HasValue)
        {
            GD.PrintErr("Player not found");
            return;
        }
        
        if (!GameManager.Instance.Players.TryGetValue(playerId.Value, out var player))
        {
            GD.PrintErr("Could not find player");
            return;
        }
        
        GD.Print($"New Pos player update: {newrow.Position}");
        player.GlobalPosition = new Vector3(newrow.Position.X, newrow.Position.Y, newrow.Position.Z);
    }

    private static void OnInsertPlayer(EventContext context, SpacetimeDB.Types.Player row)
    {
        GD.Print("Player inserted");
        var entityPosition = context.Db.Entities.EntityId.Find(row.EntityId)?.Position;
        var user = context.Db.Users.UserId.Find(row.UserId);

        if (entityPosition == null)
        {
            GD.PrintErr("Could not find entity position");
            return;
        }
        
        if (user == null)
        {
            GD.PrintErr("User not found when inserting player");
            return;
        }
        
        GameManager.Instance.SpawnPlayer(new Vector3(entityPosition.X, entityPosition.Y, entityPosition.Z), user.UserId, user.Name);
    }
}