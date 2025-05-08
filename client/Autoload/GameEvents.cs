using Godot;
using GodotClient.Types;
using SpacetimeDB.Types;

namespace GodotClient.Autoload;

public partial class GameEvents : RefCounted
{
    private static GameEvents _instance;
    
    public static GameEvents Instance => _instance ??= new();
    
    [Signal]
    public delegate void OnUserInsertedEventHandler(GameUser user);
    
    [Signal]
    public delegate void OnUserDeletedEventHandler(GameUser user);
    
    [Signal]
    public delegate void OnUserNameUpdatedEventHandler(string userName);

    [Signal]
    public delegate void OnEnterWorldEventHandler();

    public void EmitUserConnected(User user)
    {
        GD.Print("EmitUserConnected");
        EmitSignal(SignalName.OnUserInserted, GameUser.FromSpacetimeUser(user));
    }

    public void EmitUserDisconnected(User user) =>
        EmitSignal(SignalName.OnUserDeleted, GameUser.FromSpacetimeUser(user));

    public void EmitUserNameUpdated(string userName) => EmitSignal(SignalName.OnUserNameUpdated, userName);

    public void EmitEnterWorld() => EmitSignal(SignalName.OnEnterWorld);
}