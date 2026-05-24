using Godot;
using System;
using UnitConversionTool.Globals;

namespace UnitConversionTool.UI.InterfaceScenes.Navigation;
public partial class AboutButton : Button
{
	[Export] private Button _aboutButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_aboutButton.Pressed += OnAboutButtonPressed;
	}

	private void OnAboutButtonPressed()
	{
		SignalHub.EmitOnAboutButtonPressed();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}