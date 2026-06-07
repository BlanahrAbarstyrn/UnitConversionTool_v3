using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.ScreenScenes.ConverterScreen.ConverterNavigation.ButtonScenes;

public partial class ClearButton : Button
{
	[Export] private Button _clearButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_clearButton.Pressed += OnClearButtonPressed;
	}

	private void OnClearButtonPressed()
	{
		SignalHub.EmitOnClearButtonPressed();
	}
}
