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

    public void EmitUserConnected(User user)
    {
        GD.Print("EmitUserConnected");
        EmitSignal(SignalName.OnUserInserted, GameUser.FromSpacetimeUser(user));
    }

    public void EmitUserDisconnected(User user) =>
        EmitSignal(SignalName.OnUserDeleted, GameUser.FromSpacetimeUser(user));
}