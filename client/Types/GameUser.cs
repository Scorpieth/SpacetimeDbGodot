using Godot;
using SpacetimeDB.Types;

namespace GodotClient.Types;

public partial class GameUser : RefCounted
{
    public string Name { get; private set; }
    public bool Online { get; private set; }

    public GameUser(string name, bool online)
    {
        Name = name;
        Online = online;
    }

    public static GameUser FromSpacetimeUser(User user) => new GameUser(user.Name, user.Online);
}