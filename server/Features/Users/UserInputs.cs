using SpacetimeDB;
using SpacetimeDbConversionTypes;
using StdbModule.Features.HelperMethods;

namespace StdbModule.Features.Users;

public static partial class UserInputs
{
    [Reducer]
    public static void UpdateUserInput(ReducerContext ctx, SpacetimeVector3 direction)
    {
        var user = ctx.GetCurrentUser() ?? throw new Exception("User not found");
        
        
    }
}