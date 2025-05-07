using SpacetimeDB;

namespace StdbModule.domain;

[Table(Name = "Players", Public = true)]
public partial struct Player
{
    [PrimaryKey] 
    public Identity Identity;

    [Unique, AutoInc] 
    public uint Id;

    public string Name;
}