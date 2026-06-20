using Godot;

namespace UnitConversionTool.Globals;

public partial class SignalHub : Node
{
	public static SignalHub Instance { get; private set; }
	public long SelectedBgmIndex { get; set; } = -1;
	
	
	[Signal]
	public delegate void OnAboutButtonPressedEventHandler();
	
	public static void EmitOnAboutButtonPressed()
	{
		Instance.EmitSignal(SignalName.OnAboutButtonPressed);
	}
	
	
	[Signal]
	public delegate void OnBgmOptionSelectedEventHandler(long index);
	
	public static void EmitOnBgmOptionSelected(long index)
	{
		Instance.EmitSignal(SignalName.OnBgmOptionSelected, index);
	}
	
	
	[Signal]
	public delegate void OnChangelogButtonPressedEventHandler();
	
	public static void EmitOnChangelogButtonPressed()
	{
		Instance.EmitSignal(SignalName.OnChangelogButtonPressed);
	}
	
	
	[Signal]
	public delegate void OnClearButtonPressedEventHandler();
	
	public static void EmitOnClearButtonPressed()
	{
		Instance.EmitSignal(SignalName.OnClearButtonPressed);
	}

	
	[Signal]
	public delegate void OnGameOverEventHandler(bool shake);

	public static void EmitOnGameOver(bool shake)
	{
		Instance.EmitSignal(SignalName.OnGameOver, shake);
	}
	
	
	[Signal]
	public delegate void OnHighScoreChangedEventHandler(int highScore);

	public static void EmitOnHighScoreChanged(int highScore)
	{
		Instance.EmitSignal(SignalName.OnHighScoreChanged, highScore);
	}
	
	
	[Signal]
	public delegate void OnLevelChangedEventHandler(string level);

	public static void EmitOnLevelChanged(string level)
	{
		Instance.EmitSignal(SignalName.OnLevelChanged, level);
	}
	
	
	[Signal]
	public delegate void OnMainButtonPressedEventHandler();
	
	public static void EmitOnMainButtonPressed()
	{
		Instance.EmitSignal(SignalName.OnMainButtonPressed);
	}
	
	
	[Signal]
	public delegate void OnSettingsButtonPressedEventHandler();
	
	public static void EmitOnSettingsButtonPressed()
	{
		Instance.EmitSignal(SignalName.OnSettingsButtonPressed);
	}

	
	[Signal]
	public delegate void OnSubmitButtonPressedEventHandler();
	
	public static void EmitOnSubmitButtonPressed()
	{
		Instance.EmitSignal(SignalName.OnSubmitButtonPressed);
	}
	

	[Signal]
	public delegate void OnThemeOptionSelectedEventHandler(long index);
	
	public static void EmitOnThemeOptionSelected(long index)
	{
		Instance.EmitSignal(SignalName.OnThemeOptionSelected, index);
	}
	
	
	[Signal]
	public delegate void OnUserHealthChangedEventHandler(float currentHealth, float maxHealth);
	
	public static void EmitOnUserHealthChanged(float currentHealth, float maxHealth)
	{
		Instance.EmitSignal(SignalName.OnUserHealthChanged, currentHealth, maxHealth);
	}

	[Signal]
	public delegate void RequestToggleStateEventHandler(bool isPressed);

	public static void EmitRequestToggleState(bool isPressed)
	{
		Instance.EmitSignal(SignalName.RequestToggleState, isPressed);
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}
}

