using System.Collections.Generic;
using Godot;
using GodotClient.SpacetimeDb;

namespace GodotClient.Autoload;

public partial class GameManager : Node
{
    [Export] private PackedScene _playerScene;

    private Node _playersContainer;

    public Dictionary<uint, Player> Players = new();

    private static GameManager _instance;

    public static GameManager Instance => _instance;
    
    public override void _Ready()
    {
        _instance = this;
        
        SpacetimeClient.Connect();

        GameEvents.Instance.OnEnterWorld += () =>
        {
            SpacetimeClient.Reducers.EnterWorld();
        };

        _playersContainer = new Node();
        AddChild(_playersContainer);
        _playersContainer.Name = "Players";
    }

    public override void _PhysicsProcess(double delta)
    {
        SpacetimeClient.FrameTick();
    }

    public void SpawnPlayer(Vector3 position, uint playerId, string playerName)
    {
        var newPlayer = _playerScene.Instantiate<Player>();
        _playersContainer.AddChild(newPlayer);
        newPlayer.Name = $"{playerName}-{playerId}";
        Players.Add(playerId, newPlayer);
    }
}
