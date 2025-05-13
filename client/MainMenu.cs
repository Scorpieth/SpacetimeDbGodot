using Godot;
using GodotClient;
using GodotClient.Autoload;
using GodotClient.SpacetimeDb;

public partial class MainMenu : Control
{
    [Export] private Label _nameValue;
    [Export] private TextEdit _nameEdit;
    [Export] private Button _goToWorldButton;
    [Export] private Button _setNameButton;
    [Export] private Label _connectingLabel;
    
    [Export] private PackedScene _world;

    public override void _Ready()
    {
        _goToWorldButton.Disabled = true;
        _setNameButton.Disabled = true;
        
        _goToWorldButton.Pressed += () =>
        {
            var world = _world.Instantiate<TestWorldMap>();
            GetTree().Root.AddChild(world);
            world.SetUp();
            SpacetimeClient.Reducers.EnterWorld();
            Hide();
        };
        _setNameButton.Pressed += () =>
        {
            if (string.IsNullOrEmpty(_nameEdit.Text))
            {
                return;
            }
            
            SpacetimeClient.Reducers.Set(_nameEdit.Text);
        };

        GameEvents.Instance.OnUserNameUpdated += userName =>
        {
            _nameValue.Text = userName;
        };

        GameEvents.Instance.ConnectedToSpacetime += () =>
        {
            _goToWorldButton.Disabled = false;
            _setNameButton.Disabled = false;
            _connectingLabel.Text = "Connected!";
        };
    }
}
