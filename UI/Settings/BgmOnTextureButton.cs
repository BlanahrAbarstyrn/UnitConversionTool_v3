using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.UI.Settings;
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
		SignalHub.EmitOnBgmOnButtonPressed();
		GlobalValues.Instance.BgmOn = true;
	}
}
