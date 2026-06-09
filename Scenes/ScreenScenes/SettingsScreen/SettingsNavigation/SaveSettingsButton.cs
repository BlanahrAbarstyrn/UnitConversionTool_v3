using Godot;
using System;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.ScreenScenes.SettingsScreen.SettingsNavigation;
public partial class SaveSettingsButton : Button
{
    [Export] private Button _saveSettingsButton;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _saveSettingsButton.Pressed += OnSaveSettingsButtonPressed;
    }
	
    private void OnSaveSettingsButtonPressed()
    {
        SignalHub.EmitOnSaveSettingsButtonPressed();
    }
}

