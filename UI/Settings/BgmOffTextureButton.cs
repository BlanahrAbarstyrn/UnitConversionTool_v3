using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.UI.Settings;
public partial class BgmOffTextureButton : TextureButton
{
	[Export] private TextureButton _bgmOffTextureButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_bgmOffTextureButton.Pressed += OnBgmOffButtonPressed;
	}
	
	private void OnBgmOffButtonPressed()
	{
		SignalHub.EmitOnBgmOffButtonPressed();
	}
}
