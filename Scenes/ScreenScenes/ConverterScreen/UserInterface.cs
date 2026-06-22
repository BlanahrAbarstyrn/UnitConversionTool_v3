using Godot;
using UnitConversionTool.Globals;
using UnitConversionTool.Classes;
using System.Collections.Generic;
using System;

namespace UnitConversionTool.Scenes.ScreenScenes.ConverterScreen;
public partial class UserInterface : Control
{
	private SaveManager _saveManager;
	
	[Export] private TabBar _tabBar;
	[Export] private OptionButton _lengthOptionSelection;
	[Export] private OptionButton _weightOptionSelection;
	[Export] private OptionButton _pressureOptionSelection;
	[Export] private OptionButton _flowOptionSelection;
	[Export] private LineEdit _lineEditUserInput;
	[Export] private TextEdit _teOutput;
	[Export] private Button _submitButton;
	
	private BaseUnit _baseUnit;
	
	private int _highScore;
	public int HighScore
	{
		get => _highScore;
		set
		{
			_highScore = value;
			SignalHub.EmitOnHighScoreChanged(_highScore);

			if (_saveManager != null)
			{
				_saveManager.SaveProfile.HighScore = _highScore;
				_saveManager.SaveConfig();
			}
		}
	}

	private float _health;
	public float MaxHealth { get; set; } = 3f;
	
	public float Health
	{
		get => _health;
		set
		{
			// clamp the value between 0 and max health
			_health = Mathf.Clamp(value, 0f, MaxHealth);
			
			// emit signal
			SignalHub.EmitOnUserHealthChanged(_health, MaxHealth);

			if (_saveManager != null)
			{
				_saveManager.SaveProfile.Health = (int)_health;
				_saveManager.SaveConfig();
			}
		}
	}
	
	
	public override void _Ready()
	{
		_saveManager = GetNode<SaveManager>("/root/SaveManager");
		Health = _saveManager.SaveProfile.Health;
		HighScore = _saveManager.SaveProfile.HighScore;
		
		_baseUnit = new BaseUnit();
		
		_tabBar.TabClicked += OnTabBarClicked;
		_lineEditUserInput.GrabFocus();

		SignalHub.Instance.OnClearButtonPressed += OnClearButtonPressed;
		SignalHub.Instance.OnMainButtonPressed += OnMainButtonPressed;
		
		_lengthOptionSelection.ItemSelected += OnLengthOptionSelection;
		_weightOptionSelection.ItemSelected += OnWeightOptionSelection;
		_pressureOptionSelection.ItemSelected += OnPressureOptionSelection;
		_flowOptionSelection.ItemSelected += OnFlowOptionSelection;
		
		_lineEditUserInput.TextSubmitted += OnUserInputSubmitted;
		_submitButton.Pressed += OnUserInputPressed;
		
		ResetGlobals();
	}
	
	
	private void OnFlowOptionSelection(long index)
	{
		string selectedText = _flowOptionSelection.GetItemText((int) index);
		GlobalValues.Instance.SelectedUnits = selectedText;
	}
	
	private void OnPressureOptionSelection(long index)
	{
		string selectedText = _pressureOptionSelection.GetItemText((int) index);
		GlobalValues.Instance.SelectedUnits = selectedText;
	}
	
	private void OnWeightOptionSelection(long index)
	{
		string selectedText = _weightOptionSelection.GetItemText((int)index);
		GlobalValues.Instance.SelectedUnits = selectedText;
	}
	
	private void OnLengthOptionSelection(long index)
	{
		string selectedText = _lengthOptionSelection.GetItemText((int) index);
		GlobalValues.Instance.SelectedUnits = selectedText;
	}
	
	private void OnUserInputPressed()
	{
		OnUserInputSubmitted(_lineEditUserInput.Text);
	}
	
	private void OnUserInputSubmitted(string input)
	{
		_tabBar.SetMouseFilter(MouseFilterEnum.Ignore);
		_lineEditUserInput.Editable = false;
		
		DisEnAbleConvUiButton(true);
		
		GlobalValues.Instance.UserInput = input;
		
		if (GlobalValues.Instance.SelectedUnits == "Architectural feet/inches")
		{
			MeasurementParser.ParseToInches(input);
			_teOutput.Clear();
			
			if (!GlobalValues.Instance.HasError)
			{
				IReadOnlyDictionary<string, double> convertToUnits = _baseUnit.GetCategoryUnits(GlobalValues.Instance.SelectedUnits);

				if (convertToUnits == null)
				{
					_teOutput.Text = "No input units selected. Please try again.\n\nPress Reset to continue.";
					TakeDamageOnErr();
				}
				else
				{
					foreach (KeyValuePair<string, double> unit in convertToUnits)
					{
						string unitName = unit.Key;
						double unitValue = unit.Value;
						double convertedValue = unitValue * GlobalValues.Instance.ValidDouble;
						_teOutput.Text += $"{unitName}: {Math.Round(convertedValue, 4)}\n";
					}
					
					ScorePoint();
				}
				
			}
			else
			{
				_teOutput.Text = "Invalid input format. Please try again.\n\nPress Reset to continue.";
				TakeDamageOnErr();
			}
		}
		else
		{
			string rawInput = GlobalValues.Instance.UserInput;

			if (double.TryParse(rawInput, out double parsedInput))
			{
				// success
				SoundController.Instance.UiSuccess();
				GlobalValues.Instance.ValidDouble = parsedInput;
				_teOutput.Clear();
				
				IReadOnlyDictionary<string, double> convertToUnits = _baseUnit.GetCategoryUnits(GlobalValues.Instance.SelectedUnits);

				if (convertToUnits == null)
				{
					_teOutput.Text = "No input units selected. Please try again.\n\nPress Reset to continue.";
					TakeDamageOnErr();
				}
				else
				{
					foreach (KeyValuePair<string, double> unit in convertToUnits)
					{
						string unitName = unit.Key;
						double unitValue = unit.Value;
						double convertedValue = unitValue * GlobalValues.Instance.ValidDouble;
						_teOutput.Text += $"{unitName}: {Math.Round(convertedValue, 4)}\n";
					}

					ScorePoint();
				}
				
			}
			else
			{
				_teOutput.Text = "Invalid input format. Please try again.\n\nPress Reset to continue.";
				TakeDamageOnErr();
			}
		}
		
		_lineEditUserInput.ReleaseFocus();
		_teOutput.Editable = true;
		_teOutput.MouseFilter = MouseFilterEnum.Stop;
		_teOutput.ShortcutKeysEnabled = true;
		_teOutput.GrabFocus();
		
	}
	
	private void OnClearButtonPressed()
	{
		OnTabBarClicked(0);
		_tabBar.SetCurrentTab(0);
		_teOutput.Text = "Converted units will appear here.\n\n" +
		                 "HOW TO USE CONVERTER:\n" +
		                 "Select category tab.\n" +
		                 "Select input units.\n" +
		                 "Type in number to be converted.\n" +
		                 "Press Submit button or Enter on keyboard.\n\n" +
		                 "After viewing results, press Reset button\n" +
		                 "to start a new session.";
		
		_lineEditUserInput.Clear();
		_tabBar.SetMouseFilter(MouseFilterEnum.Stop);
		ResetGlobals();
		_lineEditUserInput.Editable = true;
		DisEnAbleConvUiButton(false);
		_teOutput.Editable = false;
		_teOutput.MouseFilter = MouseFilterEnum.Ignore;
		_teOutput.ReleaseFocus();
		_teOutput.ShortcutKeysEnabled = false;

		if (Health <= 0)
		{
			ResetHealth();
		}
	}

	private void ResetHealth()
	{
		Health = MaxHealth;
	}
	
	private void ScorePoint()
	{
		SoundController.Instance.UiSuccess();
		HighScore += 1;
		CheckForNewLevel(HighScore);
	}
	
	private void TakeDamageOnErr()
	{
		SoundController.Instance.UiError();
		Health -= 1;
		if (Health <= 0)
		{
			SignalHub.EmitOnGameOver(true);
			SoundController.Instance.UiGameOver();
			_teOutput.Text = "G A M E  O V E R !\n\n" +
			                 "Valid Input:\n\n" +
			                 "Whole numbers like 123 or 45933\n" +
			                 "Decimal numbers like 1.125 or 456.7\n\n" +
			                 "Architectural feet and inches:\n" +
			                 "10'-4 3/4\" or 125'-0\" etc.\n\n" +
			                 "Press Reset to continue.";
			
		}
	}

	private void CheckForNewLevel(int score)
	{
		switch (score)
		{
			case < 20:
				SignalHub.EmitOnLevelChanged("Rookie");
				break;
			case < 50:
				SignalHub.EmitOnLevelChanged("Apprentice");
				break;
			case < 100:
				SignalHub.EmitOnLevelChanged("Challenger");
				break;
			case < 10000:
				SignalHub.EmitOnLevelChanged("Warrior");
				break;
			case < 50000:
				SignalHub.EmitOnLevelChanged("Veteran");
				break;
			case < 75000:
				SignalHub.EmitOnLevelChanged("Master");
				break;
			case < 100000:
				SignalHub.EmitOnLevelChanged("Grandmaster");
				break;
			case < 250000:
				SignalHub.EmitOnLevelChanged("Legend");
				break;
			case < 500000:
				SignalHub.EmitOnLevelChanged("Immortal");
				break;
			default:
				SignalHub.EmitOnLevelChanged("Deity");
				break;
		}
	}
	
	private void OnTabBarClicked(long tab)
	{
		SoundController.Instance.UiSelect();
		_lengthOptionSelection.Visible = false;
		_weightOptionSelection.Visible = false;
		_pressureOptionSelection.Visible = false;
		_flowOptionSelection.Visible = false;
		_lineEditUserInput.Clear();
		
		switch (tab)
		{
			case 0:
				_lengthOptionSelection.Visible = true;
				_lengthOptionSelection.Selected = -1;
				break;
			case 1:
				_weightOptionSelection.Visible = true;
				_weightOptionSelection.Selected = -1;
				break;
			case 2:
				_pressureOptionSelection.Visible = true;
				_pressureOptionSelection.Selected = -1;
				break;
			case 3:
				_flowOptionSelection.Visible = true;
				_flowOptionSelection.Selected = -1;
				break;
			default:
				_tabBar.SetCurrentTab(0);
				_lengthOptionSelection.Visible = true;
				_lengthOptionSelection.Selected = -1;
				break;
		}
	}

	private void OnMainButtonPressed()
	{
		OnClearButtonPressed();
	}

	// Disable Buttons after User Input is Entered
	// Enable Button on Reset for next Conversion
	private void DisEnAbleConvUiButton(bool toggle)
	{
		var nodesInGroup = GetTree().GetNodesInGroup("ConvUiButtons");
		{
			foreach (var node in nodesInGroup)
			{
				if (node is BaseButton button)
				{
					button.Disabled = toggle;
				}
			}
		}
	}

	private void ResetGlobals()
	{
		GlobalValues.Instance.SelectedUnits = string.Empty;
		GlobalValues.Instance.UserInput = string.Empty;
		GlobalValues.Instance.HasError = false;
		GlobalValues.Instance.ValidDouble = 0;
	}
}