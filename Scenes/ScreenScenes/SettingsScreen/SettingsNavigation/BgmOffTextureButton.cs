using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.ScreenScenes.SettingsScreen.SettingsNavigation;
public partial class BgmOffTextureButton : TextureButton
{
	//[Export] private TextureButton _bgmOffTextureButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//_bgmOffTextureButton.Pressed += OnBgmOffButtonPressed;
	}
	
	private void OnBgmOffButtonPressed()
	{
		//var saveManager = GetNode<SaveManager>("/root/SaveManager");
		//SignalHub.EmitOnBgmOffButtonPressed();
		//saveManager.CurrentData.BgmOn = false;
	}
}
