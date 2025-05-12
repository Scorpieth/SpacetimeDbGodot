using SpacetimeDB;
using SpacetimeDbConversionTypes;
using StdbModule.Features.HelperMethods;

namespace StdbModule.Features.Users;

public static partial class UserInputs
{
    [Reducer]
    public static void UpdateUserInput(ReducerContext ctx, SpacetimeVector3 direction)
    {
        Log.Debug($"User Input received...");
        
        var user = ctx.GetCurrentUser() ?? throw new Exception("User not found");

        var player = ctx.Db.Players.UserId.Filter(user.UserId).First();

        player.Direction = direction;
        ctx.Db.Players.EntityId.Update(player);
    }
}