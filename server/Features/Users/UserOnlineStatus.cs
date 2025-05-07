using SpacetimeDB;
using StdbModule.domain;
using StdbModule.Features.HelperMethods;

namespace StdbModule.Features.Users;

public partial class UserOnlineStatus
{
    [Reducer(ReducerKind.ClientConnected)]
    public static void ClientConnected(ReducerContext ctx)
    {
        Log.Debug("Client connecting..");
        // var user = ctx.GetUser();
        var user = ctx.Db.Users.Identity.Find(ctx.Sender);
        if (user is null)
        {
            Log.Info("User for client not found, inserting new user.");
            ctx.Db.Users.Insert(new User(ctx.Sender,$"NewUser-{ctx.Sender}", true));
            return;
        }
        Log.Debug("User found. Setting online status.");
        user.Online = true;
        
    }
}