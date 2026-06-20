using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.ScreenScenes.SettingsScreen.SettingsNavigation;
public partial class ThemeOptionButton : OptionButton
{
	[Export] private OptionButton _themeOptionButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_themeOptionButton.ItemSelected += OnThemeOptionItemSelected;
	}

	private void OnThemeOptionItemSelected(long index)
	{
		//var saveManager = GetNode<SaveManager>("/root/SaveManager");
		SignalHub.EmitOnThemeOptionSelected(index);
		//saveManager.CurrentData.ThemeOption = index;
	}
}
