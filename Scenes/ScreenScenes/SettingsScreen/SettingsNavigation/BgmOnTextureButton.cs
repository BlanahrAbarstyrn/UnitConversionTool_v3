using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.ScreenScenes.SettingsScreen.SettingsNavigation;
public partial class BgmOnTextureButton : TextureButton
{
	[Export] private TextureButton _bgmOnTextureButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_bgmOnTextureButton.Pressed += OnBgmOnButtonPressed;
	}

	private void OnBgmOnButtonPressed()
	{
		var saveManager = GetNode<SaveManager>("/root/SaveManager");
		SignalHub.EmitOnBgmOnButtonPressed();
		saveManager.CurrentData.BgmOn = true;
		//saveManager.SaveFile();
	}
}
