using Godot;

namespace GodotClient;

public partial class TestWorldMap : Node3D
{
    [Export] private MeshInstance3D _mesh;
    [Export] private CollisionShape3D _collision;
    public void SetUp(ulong worldSize)
    {
        var size = new Vector3(worldSize, 1, worldSize);
        var boxMesh = _mesh.Mesh as BoxMesh;
        var collshape = _collision.Shape as BoxShape3D;
        boxMesh.Size = size;
        collshape.Size = size;
    }
}