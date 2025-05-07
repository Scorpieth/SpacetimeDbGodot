using System;
using System.Collections.Concurrent;
using System.Threading;
using Godot;
using SpacetimeDB;
using SpacetimeDB.Types;

namespace GodotClient.SpacetimeDb;

public sealed class SpacetimeClient
{
    private ConcurrentQueue<(string command, string args)> InputQueue = new();

    private DbConnection _connection;

    private const string Host = "http://localhost:3000";
    private const string Dbname = "spacetimegodot";
    
    private static SpacetimeClient _instance;
    
    /// <summary>
    /// Local identity of signed in user
    /// </summary>
    public Identity LocalIdentity { get; private set; }

    public bool Connected => _connection != null && _connection.IsActive;
    
    /// <summary>
    /// Gets the singleton instance of Spacetime. Always initialize the Spacetime first.
    /// </summary>
    /// <returns>
    /// The singleton instance of Spacetime that has been initialized.
    /// </returns>
    /// <exception cref="ArgumentNullException">Spacetime is null. Has not been initialized or destroyed during runtime</exception>
    public static SpacetimeClient Instance => _instance ??= new SpacetimeClient();

    public void Connect()
    {
        AuthToken.Init();
        GD.Print("Creating connection..");
        _connection = CreateSpacetimeConnection(Host, Dbname, AuthToken.Token);
        GD.Print("Registering callbacks..");
        _connection.RegisterUsersCallbacks();
    }

    private DbConnection CreateSpacetimeConnection(string host, string db, string token)
    {
        GD.Print("Connecting..");
        return DbConnection.Builder()
            .WithUri(host)
            .WithModuleName(db)
            .WithToken(token)
            .OnConnect(OnConnected)
            .OnConnectError(OnConnectError)
            .OnDisconnect(OnDisconnected)
            .Build();
    }

    private void OnConnected(DbConnection connection, Identity identity, string token)
    {
        GD.Print("Connected to SpacetimeDb");
        LocalIdentity = identity;
        AuthToken.SaveToken(token);
        
        connection.SubscriptionBuilder().SubscribeToAllTables();
    }

    private void OnConnectError(Exception e)
    {
        GD.PrintErr($"Error while connecting to SpacetimeDb: {e}");
    }

    private void OnDisconnected(DbConnection connection, Exception e)
    {
        if (e is not null)
        {
            GD.PrintErr($"Disconnected from SpacetimeDb with exception: {e}");
            return;
        }
        
        GD.Print("Disconnected from SpacetimeDb");
    }

    public void Disconnect()
    {
        _connection.Disconnect();
        _connection = null;
    }
}