using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.ScreenScenes.SettingsScreen.SettingsNavigation;
public partial class ThemeOptionButton : OptionButton
{
	private SaveManager _saveManager;
	[Export] private OptionButton _themeOptionButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_themeOptionButton.ItemSelected += OnThemeOptionItemSelected;
		_saveManager = GetNode<SaveManager>("/root/SaveManager");
	}

	private void OnThemeOptionItemSelected(long index)
	{
		SignalHub.EmitOnThemeOptionSelected(index);
		_saveManager.SaveProfile.ThemeIndex = (int)index;
		_saveManager.SaveConfig();
	}
}
