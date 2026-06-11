using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.GeneralNavigation.ChangelogButton;
public partial class ChangelogButton : Button
{
	[Export] private Button _changelogButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_changelogButton.Pressed += OnChangelogButtonPressed;
	}

	private void OnChangelogButtonPressed()
	{
		SignalHub.EmitOnChangelogButtonPressed();
	}
}
