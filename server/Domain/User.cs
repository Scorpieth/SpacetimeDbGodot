using SpacetimeDB;

namespace StdbModule.domain;

[Table(Name = "Users", Public = true)]
[Table(Name = "LoggedOutUsers")]
public partial class User
{
    [PrimaryKey] 
    public Identity Identity;
    [Unique, AutoInc,]
    public uint UserId;
    public string Name;
    
    public User()
    {
        
    }
    
    public User(Identity identity, string name)
    {
        Identity = identity;
        Name = name;
    }
}