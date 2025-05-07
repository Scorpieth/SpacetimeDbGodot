using SpacetimeDB;
using StdbModule.Features.HelperMethods;

namespace StdbModule.Features.Users;

public partial class UserName
{
    [Reducer]
    public static void Set(ReducerContext ctx, string newName)
    {
        var user = ctx.GetCurrentUser();

        if (user is null)
        {
            return;
        }

        user.Name = newName;
        ctx.Db.Users.Identity.Update(user);
    }   
}