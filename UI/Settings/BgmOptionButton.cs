using Godot;
using System;
using UnitConversionTool.Globals;

namespace UnitConversionTool.UI.Settings;

public partial class BgmOptionButton : OptionButton
{
	[Export] private OptionButton _bgmOptionButton;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Connect Signal
		_bgmOptionButton.ItemSelected += OnBgmOptionItemSelected;
		
		// RESTORE State: Set the button to the saved index
		_bgmOptionButton.Select((int)SignalHub.Instance.SelectedBgmIndex);
	}

	private void OnBgmOptionItemSelected(long index)
	{
		SignalHub.Instance.SelectedBgmIndex = index;
		SignalHub.EmitOnBgmOptionSelected(index);
		GlobalValues.Instance.BgmOption = index;
	}

}
