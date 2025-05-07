using Godot;
using GodotClient.SpacetimeDb;
using SpacetimeDB;

namespace GodotClient.Autoload;

public partial class GameManager : Node
{
    private SpacetimeClient _spacetimeClient;
    
    public override void _Ready()
    {
        // Connect to SpacetimeDB
        _spacetimeClient = SpacetimeClient.Instance;
        _spacetimeClient.Connect();
    }
}
