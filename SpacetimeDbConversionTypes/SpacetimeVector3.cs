using Godot;

namespace SpacetimeDbConversionTypes;

public struct SpacetimeVector3 : IEquatable<SpacetimeVector3>
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

    public bool Equals(SpacetimeVector3 other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
    }

    public override bool Equals(object? obj)
    {
        return obj is SpacetimeVector3 other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }
}