using Godot;
using System;
using UnitConversionTool.Globals;
using UnitConversionTool.UI.InterfaceScenes;

namespace UnitConversionTool.UI.InterfaceScenes.ToolFunctionality;

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
