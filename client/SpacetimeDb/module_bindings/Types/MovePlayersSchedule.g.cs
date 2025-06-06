// THIS FILE IS AUTOMATICALLY GENERATED BY SPACETIMEDB. EDITS TO THIS FILE
// WILL NOT BE SAVED. MODIFY TABLES IN YOUR MODULE SOURCE CODE INSTEAD.

#nullable enable

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SpacetimeDB.Types
{
    [SpacetimeDB.Type]
    [DataContract]
    public sealed partial class MovePlayersSchedule
    {
        [DataMember(Name = "Id")]
        public ulong Id;
        [DataMember(Name = "ScheduleAt")]
        public SpacetimeDB.ScheduleAt ScheduleAt;

        public MovePlayersSchedule(
            ulong Id,
            SpacetimeDB.ScheduleAt ScheduleAt
        )
        {
            this.Id = Id;
            this.ScheduleAt = ScheduleAt;
        }

        public MovePlayersSchedule()
        {
            this.ScheduleAt = null!;
        }
    }
}
