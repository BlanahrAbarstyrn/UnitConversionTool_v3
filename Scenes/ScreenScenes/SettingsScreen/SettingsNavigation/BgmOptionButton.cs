using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.ScreenScenes.SettingsScreen.SettingsNavigation;

public partial class BgmOptionButton : OptionButton
{
	[Export] private OptionButton _bgmOptionButton;
	
	private SaveManager _saveManager;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_saveManager = GetNode<SaveManager>("/root/SaveManager");
		// Connect Signal
		_bgmOptionButton.ItemSelected += OnBgmOptionItemSelected;
	}

	private void OnBgmOptionItemSelected(long index)
	{
		SignalHub.EmitOnBgmOptionSelected(index);
		_saveManager.SaveProfile.BgmIndex = (int)index;
		_saveManager.SaveConfig();
	}
}
