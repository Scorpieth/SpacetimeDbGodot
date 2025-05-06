using SpacetimeDB;
using SpacetimeDbConversionTypes;

namespace StdbModule.domain;

[Table(Name = "Entities", Public = true)]
public partial class Entity
{
    [AutoInc] 
    [PrimaryKey] 
    public int Id;
    public SpacetimeVector3 Position;
}