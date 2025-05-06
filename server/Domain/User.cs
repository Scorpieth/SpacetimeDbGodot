using SpacetimeDB;

namespace StdbModule.domain;

[Table(Name = "Users", Public = true)]
public partial class User
{
    [PrimaryKey] public Identity Identity;
    public string Name;
    public bool Online;

    public User(string name, bool online)
    {
        Name = name;
        Online = online;
    }
}