using Godot;

namespace UnitConversionTool.Globals;

public partial class SignalHub : Node
{
	public static SignalHub Instance { get; private set; }

	public long SelectedBgmIndex { get; set; } = -1;
	
	[Signal]
	public delegate void OnMainButtonPressedEventHandler();
	[Signal]
	public delegate void OnSettingsButtonPressedEventHandler();
	[Signal]
	public delegate void OnAboutButtonPressedEventHandler();
	[Signal]
	public delegate void OnChangelogButtonPressedEventHandler();
	
	[Signal]
	public delegate void OnBgmOptionSelectedEventHandler(long index);
	[Signal]
	public delegate void OnThemeOptionSelectedEventHandler(long index);

	[Signal]
	public delegate void OnClearButtonPressedEventHandler();
	[Signal]
	public delegate void OnSubmitButtonPressedEventHandler();
	
	[Signal]
	public delegate void OnSaveSettingsButtonPressedEventHandler();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	public static void EmitOnSaveSettingsButtonPressed()
	{
		Instance.EmitSignal(SignalName.OnSaveSettingsButtonPressed);
	}

	public static void EmitOnSubmitButtonPressed()
	{
		Instance.EmitSignal(SignalName.OnSubmitButtonPressed);
	}

	public static void EmitOnClearButtonPressed()
	{
		Instance.EmitSignal(SignalName.OnClearButtonPressed);
	}

	public static void EmitOnThemeOptionSelected(long index)
	{
		Instance.EmitSignal(SignalName.OnThemeOptionSelected, index);
	}
	
	public static void EmitOnBgmOptionSelected(long index)
	{
		Instance.EmitSignal(SignalName.OnBgmOptionSelected, index);
	}

	public static void EmitOnMainButtonPressed()
	{
		Instance.EmitSignal(SignalName.OnMainButtonPressed);
	}
	public static void EmitOnSettingsButtonPressed()
	{
		Instance.EmitSignal(SignalName.OnSettingsButtonPressed);
	}
	public static void EmitOnAboutButtonPressed()
	{
		Instance.EmitSignal(SignalName.OnAboutButtonPressed);
	}
	public static void EmitOnChangelogButtonPressed()
	{
		Instance.EmitSignal(SignalName.OnChangelogButtonPressed);
	}
}

