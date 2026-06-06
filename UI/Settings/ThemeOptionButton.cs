using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.UI.Settings;
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
		SignalHub.EmitOnThemeOptionSelected(index);
		GlobalValues.Instance.ThemeOption = index;
	}
}
