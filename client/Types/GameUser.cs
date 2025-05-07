using Godot;
using SpacetimeDB.Types;

namespace GodotClient.Types;

public partial class GameUser : RefCounted
{
    public string Name { get; private set; }

    public GameUser(string name)
    {
        Name = name;
    }

    public static GameUser FromSpacetimeUser(User user) => new GameUser(user.Name);
}