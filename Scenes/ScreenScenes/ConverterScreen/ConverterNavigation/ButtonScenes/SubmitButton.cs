using Godot;
using UnitConversionTool.Globals;


namespace UnitConversionTool.Scenes.ScreenScenes.ConverterScreen.ConverterNavigation.ButtonScenes;

public partial class SubmitButton : Button
{
	[Export] private Button _submitButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_submitButton.Pressed += OnSubmitButtonPressed;
	}

	private void OnSubmitButtonPressed()
	{
		SignalHub.EmitOnSubmitButtonPressed();
	}
}
