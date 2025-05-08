using SpacetimeDB;

namespace StdbModule.domain;

[Table(Name = "Worlds", Public = true)]
public partial struct ServerWorldConfig
{
    [PrimaryKey] public uint Id;
    public ulong WorldSize;

    public ServerWorldConfig()
    {
        
    }

    public ServerWorldConfig(uint id, ulong worldSize)
    {
        Id = id;
        WorldSize = worldSize;
    }
}