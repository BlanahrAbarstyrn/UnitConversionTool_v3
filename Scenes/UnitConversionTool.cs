using Godot;
using System;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes;

public partial class UnitConversionTool : Control
{
	private SaveManager _saveManager;
	
	[Export] private Control _userInterface;
	[Export] private Control _settingsUi;
	[Export] private Control _aboutUi;
	[Export] private Control _changelogUi;
	[Export] private Control _licenseUi;
	[Export] private Button _mainButton;
	[Export] private Button _aboutOnChangelogSceneButton;
	[Export] private Button _aboutOnLicenseSceneButton;
	[Export] private LineEdit _lineEditUserInput;
	[Export] private TabBar _tabBar;
	[Export] private Button _changelogButton;
	[Export] private Button _licenseButton;

	
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
		SignalHub.Instance.OnLicenseButtonPressed += OnLicenseButtonPressed;
		
		// Hooks up all buttons to UI effects sounds
		SoundController.Instance.SetupButtonAudio(this);
		
		_saveManager = GetNode<SaveManager>("/root/SaveManager");
		ThemeManager.Instance.SetThemeByIndex(_saveManager.SaveProfile.ThemeIndex);
	}

	public override void _ExitTree()
	{
		SignalHub.Instance.OnMainButtonPressed -= OnMainButtonPressed;
		SignalHub.Instance.OnSettingsButtonPressed -= OnSettingsButtonPressed;
		SignalHub.Instance.OnAboutButtonPressed -= OnAboutButtonPressed;
		SignalHub.Instance.OnChangelogButtonPressed -= OnChangelogButtonPressed;
		SignalHub.Instance.OnThemeOptionSelected -= OnThemeOptionSelected;
		SignalHub.Instance.OnLicenseButtonPressed -= OnLicenseButtonPressed;
	}
	
	
	private void OnThemeOptionSelected(long index)
	{
		ThemeManager.Instance.SetThemeByIndex((int)index);
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
	
	private void OnLicenseButtonPressed()
	{
		ShowLicenseUi(true);
	}

	private void ShowUserInterface(bool show)
	{
		_userInterface.Visible = show;
		_settingsUi.Visible = !show;
		_aboutUi.Visible = !show;
		_changelogUi.Visible = !show;
		_licenseUi.Visible = !show;
		_tabBar.GrabFocus();
	}
	
	private void ShowSettings(bool show)
	{
		_settingsUi.Visible = show;
		_aboutUi.Visible = !show;
		_changelogUi.Visible = !show;
		_licenseUi.Visible = !show;
		_mainButton.GrabFocus();
	}

	private void ShowAboutUi(bool show)
	{
		_aboutUi.Visible = show;
		_changelogUi.Visible = !show;
		_licenseUi.Visible = !show;
		_changelogButton.GrabFocus();

	}

	private void ShowChangelogUi(bool show)
	{
		_changelogUi.Visible = show;
		_licenseUi.Visible = !show;
		_aboutOnChangelogSceneButton.GrabFocus();
	}
	
	private void ShowLicenseUi(bool show)
	{
		_licenseUi.Visible = show;
		_aboutOnLicenseSceneButton.GrabFocus();
	}
}
