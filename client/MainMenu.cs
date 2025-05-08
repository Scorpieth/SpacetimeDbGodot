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

    [Export] private PackedScene _world;

    public override void _Ready()
    {
        _goToWorldButton.Pressed += () =>
        {
            var world = _world.Instantiate<TestWorldMap>();
            GetTree().Root.AddChild(world);
            world.SetUp(SpacetimeClient.Db.Worlds.Id.Find(0)?.WorldSize ?? 1);
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
    }
}
