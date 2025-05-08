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

    public static SpacetimeVector3 operator +(SpacetimeVector3 a, SpacetimeVector3 b) =>
        new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    
    public static SpacetimeVector3 operator -(SpacetimeVector3 a, SpacetimeVector3 b) =>
        new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

    public static SpacetimeVector3 operator *(SpacetimeVector3 a, float b) => new(a.X * b, a.Y * b, a.Z * b);
    public static SpacetimeVector3 operator /(SpacetimeVector3 a, float b) => new(a.X / b, a.Y / b, a.Z / b);
}