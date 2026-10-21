using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.ScreenScenes.SettingsScreen.SettingsNavigation;
public partial class AppSizeOptions : OptionButton
{
	private SaveManager _saveManager;
	[Export] private OptionButton _appSizeButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_appSizeButton.ItemSelected += OnAppSizeItemSelected;
		_saveManager = GetNode<SaveManager>("/root/SaveManager");
	}

	private void OnAppSizeItemSelected(long index)
	{
		SignalHub.EmitOnAppSizeItemSelected(index);
		//_saveManager.SaveProfile.ThemeIndex = (int)index;
		_saveManager.SaveConfig();
	}
}
