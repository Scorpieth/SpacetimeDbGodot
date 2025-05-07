using Godot;

namespace SpacetimeDbConversionTypes;

[SpacetimeDB.Type]
public partial struct SpacetimeVector3
{
    public float X;
    public float Y;
    public float Z;
    
    public SpacetimeVector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    public Vector3 ToGodotVector3() => new(X, Y, Z);
}