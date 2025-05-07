using Godot;
using GodotClient.SpacetimeDb;
using GodotClient.Types;

namespace GodotClient.Autoload;

public partial class GameManager : Node
{
    public GameUser CurrentUser => _currentUser;
    private GameUser _currentUser;
    
    private SpacetimeClient _spacetimeClient;
    
    public override void _Ready()
    {
        // Connect to SpacetimeDB
        _spacetimeClient = SpacetimeClient.Instance;
        _spacetimeClient.Connect();
    }

    public override void _PhysicsProcess(double delta)
    {
        _spacetimeClient.Connection.FrameTick();
    }
}
