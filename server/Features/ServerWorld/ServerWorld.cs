using SpacetimeDB;
using SpacetimeDbConversionTypes;
using StdbModule.domain;
using StdbModule.Features.HelperMethods;

namespace StdbModule.Features.ServerWorld;

public partial class ServerWorld
{
    [Reducer]
    public static void EnterWorld(ReducerContext ctx)
    {
        var user = ctx.GetCurrentUser();
        SpawnUserEntity(ctx, user.UserId);
    }

    private static Entity SpawnUserEntity(ReducerContext ctx, uint userId)
    {
        var entity = new Entity(userId, new SpacetimeVector3(5, 2, 5));
        ctx.Db.Entities.Insert(entity);
        
        return entity;
    }
}