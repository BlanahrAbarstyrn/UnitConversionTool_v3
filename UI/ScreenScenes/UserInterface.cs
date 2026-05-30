using Godot;
using UnitConversionTool.Globals;
using UnitConversionTool.Classes;
using System.Collections.Generic;
using System;

namespace UnitConversionTool.UI.ScreenScenes;
public partial class UserInterface : Control
{
	private BaseUnit _baseUnit;
	
	[Export] private TabBar _tabBar;
	[Export] private OptionButton _lengthOptionSelection;
	[Export] private OptionButton _weightOptionSelection;
	[Export] private OptionButton _pressureOptionSelection;
	[Export] private OptionButton _flowOptionSelection;
	[Export] private LineEdit _lineEditUserInput;
	[Export] private TextEdit _teOutput;
	[Export] private Button _submitButton;
	
	public override void _Ready()
	{
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
		
		GlobalValues.Instance.SelectedUnits = string.Empty;
		GlobalValues.Instance.UserInput = string.Empty;
		GlobalValues.Instance.HasError = false;
		GlobalValues.Instance.ValidDecimal = 0;
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
		_lengthOptionSelection.Disabled = true;
		_weightOptionSelection.Disabled = true;
		_pressureOptionSelection.Disabled = true;
		_flowOptionSelection.Disabled = true;
		_submitButton.Disabled = true;
		
		GlobalValues.Instance.UserInput = input;

		if (GlobalValues.Instance.SelectedUnits == "Architectural feet/inches")
		{
			MeasurementParser.ParseToInches(input);
			_teOutput.Clear();
			
			if (!GlobalValues.Instance.HasError)
			{
				IReadOnlyDictionary<string, decimal> convertToUnits = _baseUnit.GetCategoryUnits(GlobalValues.Instance.SelectedUnits);

				if (convertToUnits == null)
				{
					_teOutput.Text = "No input units selected. Please try again.\n\nPress Reset to continue.";
				}
				else
				{
					foreach (KeyValuePair<string, decimal> unit in convertToUnits)
					{
						string unitName = unit.Key;
						decimal unitValue = unit.Value;
						decimal convertedValue = unitValue * GlobalValues.Instance.ValidDecimal;
						_teOutput.Text += $"{unitName}: {Math.Round(convertedValue, 4)}\n";
					}
				}
				
				//_teOutput.Text = ($"{GlobalValues.Instance.ValidDouble} inches\n\nPress Reset to continue.");
			}
			else
			{
				_teOutput.Text = "Invalid input format. Please try again.\n\nPress Reset to continue.";
				GlobalValues.Instance.HasError = false;
			}
		}
		else
		{
			string rawInput = GlobalValues.Instance.UserInput;

			if (decimal.TryParse(rawInput, out decimal parsedInput))
			{
				// success
				GlobalValues.Instance.ValidDecimal = parsedInput;
				_teOutput.Clear();
				//_teOutput.Text = ($"{GlobalValues.Instance.ValidDecimal} valid input\n\nPress Reset to continue.");
				
				IReadOnlyDictionary<string, decimal> convertToUnits = _baseUnit.GetCategoryUnits(GlobalValues.Instance.SelectedUnits);

				if (convertToUnits == null)
				{
					_teOutput.Text = "No input units selected. Please try again.\n\nPress Reset to continue.";
				}
				else
				{
					foreach (KeyValuePair<string, decimal> unit in convertToUnits)
					{
						string unitName = unit.Key;
						decimal unitValue = unit.Value;
						decimal convertedValue = unitValue * GlobalValues.Instance.ValidDecimal;
						_teOutput.Text += $"{unitName}: {Math.Round(convertedValue, 4)}\n";
					}
				}
				
			}
			else
			{
				_teOutput.Text = "Invalid input format. Please try again.\n\nPress Reset to continue.";
			}
		}
		
		GlobalValues.Instance.SelectedUnits = string.Empty;
		GlobalValues.Instance.UserInput = string.Empty;
		
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
		_teOutput.Text = "Converted units will appear here";
		_lineEditUserInput.Clear();
		_tabBar.SetMouseFilter(MouseFilterEnum.Stop);
		GlobalValues.Instance.SelectedUnits = string.Empty;
		GlobalValues.Instance.UserInput = string.Empty;
		GlobalValues.Instance.HasError = false;
		GlobalValues.Instance.ValidDecimal = 0;
		_lineEditUserInput.Editable = true;
		_lengthOptionSelection.Disabled = false;
		_weightOptionSelection.Disabled = false;
		_pressureOptionSelection.Disabled = false;
		_flowOptionSelection.Disabled = false;
		_submitButton.Disabled = false;
		_teOutput.Editable = false;
		_teOutput.MouseFilter = MouseFilterEnum.Ignore;
		_teOutput.ReleaseFocus();
		_teOutput.ShortcutKeysEnabled = false;
	}

	private void OnTabBarClicked(long tab)
	{
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
}