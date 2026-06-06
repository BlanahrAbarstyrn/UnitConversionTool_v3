using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.UI.Settings;
public partial class SfxOnTextureButton : TextureButton
{
	[Export] private TextureButton _sfxOnTextureButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_sfxOnTextureButton.Pressed += OnSfxOnButtonPressed;
	}
	
	private void OnSfxOnButtonPressed()
	{
		var saveManager = GetNode<SaveManager>("/root/SaveManager");
		SignalHub.EmitOnSfxOnButtonPressed();
		saveManager.CurrentData.EffectsOn = true;
		saveManager.SaveFile();
	}
}
