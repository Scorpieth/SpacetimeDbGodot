using Godot;
using GodotClient.SpacetimeDb;
using SpacetimeDB.Types;

namespace GodotClient.Components;

public partial class MovementSynchronizer : Node
{
    private ulong _tickRate = 33;
    private Node3D _parent;
    
    public override void _Ready()
    {
        GD.Print("MovementSynchronizer init...");
        _parent = GetParent<Node3D>();
    }

    public override void _Process(double delta)
    {
        var dir = Input.GetVector("Left", "Right", "Up", "Down");
        // Allows for movement dependent on the rotation of the parent node
        var normalizedDir = -_parent.Transform.Basis.Z * dir.Y + _parent.Transform.Basis.X * dir.X;
        
        if (delta > _tickRate)
        {
            return;
        }
        GD.Print("Sending Input to Server");
        SpacetimeClient.Reducers.UpdateUserInput(new SpacetimeVector3(normalizedDir.X, 0, normalizedDir.Y));
    }
}