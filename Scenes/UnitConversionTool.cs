using Godot;
using System;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes;

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
				window.MinSize = new Vector2I(420, 560); // Minimum width and height
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
		SignalHub.Instance.OnThemeOptionSelected += OnThemeOptionSelected;
	}

	private void OnThemeOptionSelected(long index)
	{
		switch (index)
		{
			case 0:
				Theme = GD.Load("uid://vrb8t8tcj57i") as Theme;
				break;
			case 1:
				Theme = GD.Load("uid://dxjqn3ak1ujs7") as Theme;
				break;
			case 2:
				Theme = GD.Load("uid://b56x1l0aqfs1r") as Theme;
				break;
			case 3:
				Theme = GD.Load("uid://bd8ijvuhkewrb") as Theme;
				break;
			case 4:
				Theme = GD.Load("uid://d6gahkl5aae4") as Theme;
				break;
			default:
				Theme = GD.Load("uid://vrb8t8tcj57i") as Theme;
				break;
		}
	}
	
	private void OnMainButtonPressed()
	{
		ShowUserInterface(true);
		
		var saveManager = GetNode<SaveManager>("/root/SaveManager");
		saveManager.SaveFile();
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
