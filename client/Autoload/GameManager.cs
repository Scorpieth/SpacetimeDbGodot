using Godot;
using GodotClient.SpacetimeDb;
using GodotClient.Types;

namespace GodotClient.Autoload;

public partial class GameManager : Node
{
    public GameUser CurrentUser => _currentUser;
    private GameUser _currentUser;
    
    
    public override void _Ready()
    {
        SpacetimeClient.Connect();
    }

    public override void _PhysicsProcess(double delta)
    {
        SpacetimeClient.FrameTick();
    }
}
