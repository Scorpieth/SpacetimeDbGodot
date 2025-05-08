using SpacetimeDB;
using SpacetimeDbConversionTypes;

namespace StdbModule.domain;

[Table(Name = "Entities", Public = true)]
public partial struct Entity
{
    [AutoInc] 
    [PrimaryKey] 
    public uint EntityId;
    
    public SpacetimeVector3 Position;

    public Entity() { }

    public Entity(SpacetimeVector3 position)
    {
        Position = position;
    }
}