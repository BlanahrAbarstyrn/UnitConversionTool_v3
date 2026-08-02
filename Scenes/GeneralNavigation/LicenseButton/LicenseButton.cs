using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.GeneralNavigation.LicenseButton;
public partial class LicenseButton : Button
{
	[Export] private Button _licenseButton;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_licenseButton.Pressed += OnLicenseButtonPressed;
	}

	private void OnLicenseButtonPressed()
	{
		SignalHub.EmitOnLicenseButtonPressed();
	}
}
