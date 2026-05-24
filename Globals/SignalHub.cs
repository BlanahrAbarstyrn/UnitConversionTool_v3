using Godot;
using System;

namespace UnitConversionTool.Globals;

public partial class SignalHub : Node
{
	public static SignalHub Instance { get; private set; }

	[Signal]
	public delegate void OnMainButtonPressedEventHandler();
	[Signal]
	public delegate void OnSettingsButtonPressedEventHandler();
	[Signal]
	public delegate void OnAboutButtonPressedEventHandler();
	[Signal]
	public delegate void OnChangelogButtonPressedEventHandler();


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
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

