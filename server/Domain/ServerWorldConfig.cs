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

    public ServerWorldConfig(ulong worldSize)
    {
        WorldSize = worldSize;
    }
}