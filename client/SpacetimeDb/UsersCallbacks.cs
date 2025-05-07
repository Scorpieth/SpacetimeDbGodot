using Godot;
using GodotClient.Autoload;
using SpacetimeDB.Types;

namespace GodotClient.SpacetimeDb;

public static class UsersCallbacks
{
    public static DbConnection RegisterUsersCallbacks(this DbConnection connection)
    {
        connection.Db.Users.OnInsert += UserInserted;
        connection.Db.Users.OnUpdate += UserUpdated;
        GD.Print("User callbacks registered..");
        return connection;
    }

    private static void UserUpdated(EventContext context, User oldUser, User newUser)
    {
        GD.Print("User updated");
    }

    private static void UserInserted(EventContext ctx, User user)
    {
        GD.Print("User inserted");
        GameEvents.Instance.EmitUserConnected(user);
    }
}