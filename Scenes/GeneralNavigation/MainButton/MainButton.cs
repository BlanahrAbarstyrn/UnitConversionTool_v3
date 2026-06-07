using Godot;
using UnitConversionTool.Globals;


namespace UnitConversionTool.Scenes.GeneralNavigation.MainButton;
public partial class MainButton : Button
{
	[Export] private Button _mainButton;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_mainButton.Pressed += OnMainButtonPressed;
	}

	private void OnMainButtonPressed()
	{
		SignalHub.EmitOnMainButtonPressed();
	}
}
