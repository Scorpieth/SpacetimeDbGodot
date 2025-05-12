using SpacetimeDB;
using SpacetimeDbConversionTypes;

namespace StdbModule.Features.Players;

public static partial class Movement
{
    [Table(Name = "MovePlayersSchedules", Scheduled = nameof(MovePlayers), ScheduledAt = nameof(ScheduleAt))]
    public partial struct MovePlayersSchedule()
    {
        [PrimaryKey] [AutoInc] public ulong Id;

        public ScheduleAt ScheduleAt;
    }
    
    [Reducer]
    public static void MovePlayers(ReducerContext ctx, MovePlayersSchedule timer)
    {
        var playerDirections = ctx.Db.Players.Iter()
            .Select(x => (x.EntityId, x.Direction * x.Speed))
            .ToDictionary();

        foreach (var player in ctx.Db.Players.Iter())
        {
            var playerDbEntity = ctx.Db.Entities.EntityId.Find(player.EntityId);
            if (playerDbEntity is null)
            {
                return;
            }

            var playerEntity = playerDbEntity.Value;
            var direction = playerDirections[playerEntity.EntityId];
            var newPos = playerEntity.Position + direction * player.Speed;
            playerEntity.Position = newPos;
            ctx.Db.Entities.EntityId.Update(playerEntity);
        }
        
        ctx.Db.MovePlayersSchedules.Insert(new MovePlayersSchedule()
        {
            ScheduleAt = new ScheduleAt.Time(ctx.Timestamp + new TimeDuration(33333)),
        });
    }
}