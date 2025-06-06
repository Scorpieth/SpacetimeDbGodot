// THIS FILE IS AUTOMATICALLY GENERATED BY SPACETIMEDB. EDITS TO THIS FILE
// WILL NOT BE SAVED. MODIFY TABLES IN YOUR MODULE SOURCE CODE INSTEAD.

#nullable enable

using System;
using SpacetimeDB.ClientApi;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SpacetimeDB.Types
{
    public sealed partial class RemoteReducers : RemoteBase
    {
        public delegate void UpdateUserInputHandler(ReducerEventContext ctx, SpacetimeVector3 direction);
        public event UpdateUserInputHandler? OnUpdateUserInput;

        public void UpdateUserInput(SpacetimeVector3 direction)
        {
            conn.InternalCallReducer(new Reducer.UpdateUserInput(direction), this.SetCallReducerFlags.UpdateUserInputFlags);
        }

        public bool InvokeUpdateUserInput(ReducerEventContext ctx, Reducer.UpdateUserInput args)
        {
            if (OnUpdateUserInput == null)
            {
                if (InternalOnUnhandledReducerError != null)
                {
                    switch (ctx.Event.Status)
                    {
                        case Status.Failed(var reason): InternalOnUnhandledReducerError(ctx, new Exception(reason)); break;
                        case Status.OutOfEnergy(var _): InternalOnUnhandledReducerError(ctx, new Exception("out of energy")); break;
                    }
                }
                return false;
            }
            OnUpdateUserInput(
                ctx,
                args.Direction
            );
            return true;
        }
    }

    public abstract partial class Reducer
    {
        [SpacetimeDB.Type]
        [DataContract]
        public sealed partial class UpdateUserInput : Reducer, IReducerArgs
        {
            [DataMember(Name = "direction")]
            public SpacetimeVector3 Direction;

            public UpdateUserInput(SpacetimeVector3 Direction)
            {
                this.Direction = Direction;
            }

            public UpdateUserInput()
            {
                this.Direction = new();
            }

            string IReducerArgs.ReducerName => "UpdateUserInput";
        }
    }

    public sealed partial class SetReducerFlags
    {
        internal CallReducerFlags UpdateUserInputFlags;
        public void UpdateUserInput(CallReducerFlags flags) => UpdateUserInputFlags = flags;
    }
}
