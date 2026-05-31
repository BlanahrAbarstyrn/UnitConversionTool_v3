using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.UI.InterfaceScenes.Navigation;
public partial class SettingsButton : Button
{
	[Export] private Button _settingsButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_settingsButton.Pressed += OnSettingsButtonPressed;
	}

	private void OnSettingsButtonPressed()
	{
		SignalHub.EmitOnSettingsButtonPressed();
	}
}
