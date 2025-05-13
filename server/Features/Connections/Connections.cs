using SpacetimeDB;
using StdbModule.domain;

namespace StdbModule.Features.Connections;

public partial class Connections
{
    [Reducer(ReducerKind.ClientConnected)]
    public static void ClientConnected(ReducerContext ctx)
    {
        Log.Debug("Client connecting..");
        // var user = ctx.GetUser();
        var user = ctx.Db.LoggedOutUsers.Identity.Find(ctx.Sender);
        if (user is null)
        {
            Log.Info("User for client not found, inserting new user.");
            ctx.Db.Users.Insert(new User(ctx.Sender,$"NewUser-{ctx.Sender}"));
            return;
        }
        Log.Debug("User found. Setting online status.");
        ctx.Db.Users.Insert(user);
        ctx.Db.LoggedOutUsers.Identity.Delete(user.Identity);

    }

    [Reducer(ReducerKind.ClientDisconnected)]
    public static void ClientDisconnected(ReducerContext ctx)
    {
        var user = ctx.Db.Users.Identity.Find(ctx.Sender);
        if (user is null)
        {
            Log.Debug("User not found when disconnecting.");
            return;
        }

        ctx.Db.Entities.EntityId.Delete(user.UserId);
        ctx.Db.Players.UserId.Delete(user.UserId);
        ctx.Db.LoggedOutUsers.Insert(user);
        ctx.Db.Users.Identity.Delete(user.Identity);
    }
}