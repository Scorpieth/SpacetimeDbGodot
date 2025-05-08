using SpacetimeDB;
using SpacetimeDbConversionTypes;

namespace StdbModule.domain;

[Table(Name = "Players", Public = true)]
public partial struct Player
{
    [PrimaryKey] 
    public uint EntityId;
    [SpacetimeDB.Index.BTree] 
    public uint UserId;

    public SpacetimeVector3 Direction;
    public float Speed;
}