using Godot;
using GodotClient.SpacetimeDb;

namespace GodotClient.Autoload;

public partial class GameManager : Node
{
    public override void _Ready()
    {
        SpacetimeClient.Connect();

        GameEvents.Instance.OnEnterWorld += () =>
        {
            SpacetimeClient.Reducers.EnterWorld();
        };
    }

    public override void _PhysicsProcess(double delta)
    {
        SpacetimeClient.FrameTick();
    }
}
