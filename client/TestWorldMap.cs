using Godot;
using GodotClient.SpacetimeDb;

namespace GodotClient;

public partial class TestWorldMap : Node3D
{
    [Export] private MeshInstance3D _mesh;
    [Export] private CollisionShape3D _collision;
    public void SetUp()
    {
        var worldSize = SpacetimeClient.Db.Worlds.Id.Find(0)?.WorldSize ?? 1;
        GD.Print(worldSize);
        var size = new Vector3(worldSize, 1, worldSize);
        var boxMesh = _mesh.Mesh as BoxMesh;
        var collshape = _collision.Shape as BoxShape3D;
        boxMesh.Size = size;
        collshape.Size = size;
    }
}