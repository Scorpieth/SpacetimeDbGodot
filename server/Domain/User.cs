using SpacetimeDB;

namespace StdbModule.domain;

[Table(Name = "Users", Public = true)]
public partial class User
{
    [PrimaryKey] public Identity Identity;
    public string Name;
    public bool Online;

    public User()
    {
        
    }
    
    public User(Identity identity, string name, bool online)
    {
        Identity = identity;
        Name = name;
        Online = online;
    }
}