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
        if (oldUser.Online != newUser.Online)
        {
            GameEvents.Instance.EmitUserOnlineStatusChanged(newUser);
        }
    }

    private static void UserInserted(EventContext ctx, User user)
    {
        if (user.Online)
        {
            GameEvents.Instance.EmitUserConnected(user);
        }
    }
}