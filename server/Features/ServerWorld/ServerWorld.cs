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
        SpawnUserPlayer(ctx, user.UserId);
    }

    private static Entity SpawnUserPlayer(ReducerContext ctx, uint userId)
    {
        var entity = ctx.Db.Entities.Insert(new Entity(new SpacetimeVector3(5, 2, 5)));

        ctx.Db.Players.Insert(new Player
        {
            UserId = userId,
            EntityId = entity.EntityId,
            Direction = new SpacetimeVector3(0, 0, 0),
            Speed = 0f,
        });
        
        return entity;
    }
}