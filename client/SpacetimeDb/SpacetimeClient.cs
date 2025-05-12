using System;
using System.Collections.Concurrent;
using Godot;
using SpacetimeDB;
using SpacetimeDB.Types;

namespace GodotClient.SpacetimeDb;

/// <summary>
/// Stdb singleton client.<br/> Initialize this client by running Connect in the _Ready method of where you want to connect to stdb.
/// </summary>
public sealed class SpacetimeClient
{
    private ConcurrentQueue<(string command, string args)> InputQueue = new();

    private DbConnection _connection;

    private const string Host = "http://localhost:3000";
    private const string Dbname = "spacetimegodot";
    
    private static SpacetimeClient _instance;

    private Identity _localIdentity;

    /// <summary>
    /// Local identity of signed in user
    /// </summary>
    public static Identity LocalIdentity => Instance._localIdentity;

    /// <summary>
    /// Shorthand accessor for Remote Reducers (stdb server calls)
    /// </summary>
    public static RemoteReducers Reducers => Instance._connection.Reducers;

    /// <summary>
    /// Shorthand accessor for Remote Tables
    /// </summary>
    public static RemoteTables Db => Instance._connection.Db;
    public bool Connected => _connection != null && _connection.IsActive;
    
    /// <summary>
    /// Gets the singleton instance of Spacetime. Always initialize the Spacetime first.
    /// </summary>
    /// <returns>
    /// The singleton instance of SpacetimeClient.
    /// </returns>
    public static SpacetimeClient Instance => _instance ??= new SpacetimeClient();

    public static void Connect()
    {
        AuthToken.Init();
        GD.Print("Creating connection..");
        Instance._connection = Instance.CreateSpacetimeConnection(Host, Dbname, AuthToken.Token);
        GD.Print("Registering callbacks..");
        Instance._connection.RegisterUsersCallbacks();
        Instance._connection.RegisterEntityCallbacks();
    }

    /// <summary>
    /// Run this in a constantly running process. You need this to get served with callbacks from stdb. <br/><br/>
    /// Recommended to run in PhysicsProcess
    /// </summary>
    public static void FrameTick()
    {
        Instance._connection.FrameTick();
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
        _localIdentity = identity;
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