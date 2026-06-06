using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.UI.Settings;
public partial class SfxOffTextureButton : TextureButton
{
	[Export] private TextureButton _sfxOffTextureButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_sfxOffTextureButton.Pressed += OnSfxOffButtonPressed;
	}
	
	private void OnSfxOffButtonPressed()
	{
		var saveManager = GetNode<SaveManager>("/root/SaveManager");
		SignalHub.EmitOnSfxOffButtonPressed();
		saveManager.CurrentData.EffectsOn = false;
		saveManager.SaveFile();
	}
}
