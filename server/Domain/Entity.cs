using SpacetimeDB;
using SpacetimeDbConversionTypes;

namespace StdbModule.domain;

[Table(Name = "Entities", Public = true)]
public partial struct Entity
{
    [AutoInc] 
    [PrimaryKey] 
    public uint Id;
    public SpacetimeVector3 Position;

    public Entity()
    {
        
    }

    public Entity(uint id, SpacetimeVector3 position)
    {
        Id = id;
        Position = position;
    }
}