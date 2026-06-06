using Godot;
using UnitConversionTool.Globals;
using UnitConversionTool.Classes;

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
		var saveManager = GetNode<SaveManager>("/root/SaveManager");
		SignalHub.EmitOnThemeOptionSelected(index);
		saveManager.CurrentData.ThemeOption = index;
		saveManager.SaveFile();
	}
}
