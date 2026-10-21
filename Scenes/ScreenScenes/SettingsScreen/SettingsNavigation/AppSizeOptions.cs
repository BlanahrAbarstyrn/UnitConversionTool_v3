using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.ScreenScenes.SettingsScreen.SettingsNavigation;
public partial class AppSizeOptions : OptionButton
{
	[Export] private OptionButton _appSizeButton;
	
	public long SetSizeByIndex { get; set; } = -1;
	
	private SaveManager _saveManager;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_saveManager = GetNode<SaveManager>("/root/SaveManager");
		_appSizeButton.ItemSelected += OnAppSizeItemSelected;
	}

	private void OnAppSizeItemSelected(long index)
	{
		_saveManager.SaveProfile.AppSizeIndex = (int)index;
		_saveManager.SaveConfig();
	}
}
