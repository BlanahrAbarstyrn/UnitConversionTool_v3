using Godot;
using System;
using UnitConversionTool.Globals;

namespace UnitConversionTool;

public partial class UnitConversionTool : Control
{
	[Export] private Control _userInterface;
	[Export] private Control _settingsUi;
	[Export] private Control _aboutUi;
	[Export] private Control _changelogUi;
	
	
	// Called when the node enters the scene tree for the first time.
	public override async void _Ready()
	{
		try
		{
			await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
			Window window = GetWindow();
			if (window != null)
			{
				window.MinSize = new Vector2I(360, 480); // Minimum width and height
				window.MaxSize = new Vector2I(720, 960); // Maximum and design width and height
			}
		}
		catch (Exception ex)
		{
			GD.PrintErr($"Error in _Ready: {ex.Message}");
			// Handle or log the exception
		}

		
		ShowUserInterface(true);
		SignalHub.Instance.OnMainButtonPressed += OnMainButtonPressed;
		SignalHub.Instance.OnSettingsButtonPressed += OnSettingsButtonPressed;
		SignalHub.Instance.OnAboutButtonPressed += OnAboutButtonPressed;
		SignalHub.Instance.OnChangelogButtonPressed += OnChangelogButtonPressed;
	}

	private void OnMainButtonPressed()
	{
		ShowUserInterface(true);
	}
	
	private void OnSettingsButtonPressed()
	{
		ShowSettings(true);
	}

	private void OnAboutButtonPressed()
	{
		ShowAboutUi(true);
	}
	
	private void OnChangelogButtonPressed()
	{
		ShowChangelogUi(true);
	}

	private void ShowUserInterface(bool show)
	{
		_userInterface.Visible = show;
		_settingsUi.Visible = !show;
		_aboutUi.Visible = !show;
		_changelogUi.Visible = !show;
	}
	
	private void ShowSettings(bool show)
	{
		_settingsUi.Visible = show;
		_aboutUi.Visible = !show;
		_changelogUi.Visible = !show;
	}

	private void ShowAboutUi(bool show)
	{
		_aboutUi.Visible = show;
		_changelogUi.Visible = !show;
	}

	private void ShowChangelogUi(bool show)
	{
		_changelogUi.Visible = show;
	}
}
