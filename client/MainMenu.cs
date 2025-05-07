using Godot;

public partial class MainMenu : Control
{
    [Export] private Label _nameValue;
    [Export] private Button _goToWorldButton;
    [Export] private Button _setNameButton;

    public override void _Ready()
    {
        _goToWorldButton.Pressed += () => { };
        _setNameButton.Pressed += () => { };
        
        
    }
}
