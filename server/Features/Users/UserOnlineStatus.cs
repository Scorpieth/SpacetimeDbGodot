using SpacetimeDB;
using StdbModule.domain;
using StdbModule.Features.HelperMethods;

namespace StdbModule.Features.Users;

public partial class UserOnlineStatus
{
    [Reducer(ReducerKind.ClientConnected)]
    public static void ClientConnected(ReducerContext ctx)
    {
        var user = ctx.GetUser();

        if (user is null)
        {
            ctx.Db.Users.Insert(new User($"NewUser-{ctx.Sender}", true));
            return;
        }

        user.Online = true;
        
    }
}