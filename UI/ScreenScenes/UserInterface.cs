using System.Text.RegularExpressions;
using Godot;
using UnitConversionTool.Globals;
using UnitConversionTool.Classes;


namespace UnitConversionTool.UI.ScreenScenes;
public partial class UserInterface : Control
{
	[Export] private TabBar _tabBar;

	
	// refactor to use one OptionButton
	[Export] private OptionButton _lengthOptionSelection;
	[Export] private OptionButton _weightOptionSelection;
	[Export] private OptionButton _pressureOptionSelection;
	[Export] private OptionButton _flowOptionSelection;
	
	[Export] private LineEdit _lineEditUserInput;
	[Export] private TextEdit _teOutput;
	
	[Export] private Button _submitButton;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_tabBar.TabClicked += OnTabBarClicked;
		_lineEditUserInput.GrabFocus();

		SignalHub.Instance.OnClearButtonPressed += OnClearButtonPressed;
		//SignalHub.Instance.OnSubmitButtonPressed += OnSubmitButtonPressed;

		_lengthOptionSelection.ItemSelected += OnLengthOptionSelection;
		_weightOptionSelection.ItemSelected += OnWeightOptionSelection;
		_pressureOptionSelection.ItemSelected += OnPressureOptionSelection;
		_flowOptionSelection.ItemSelected += OnFlowOptionSelection;
		
		_lineEditUserInput.TextSubmitted += OnUserInputSubmitted;
		_submitButton.Pressed += OnUserInputPressed;
		
		GlobalValues.Instance.SelectedUnits = string.Empty;
		GlobalValues.Instance.UserInput = string.Empty;
		GlobalValues.Instance.HasError = false;
		GlobalValues.Instance.ValidDouble = 0.0;
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
				_teOutput.Text = ($"{GlobalValues.Instance.ValidDouble} inches\n\nPress Reset to continue.");
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

			if (double.TryParse(rawInput, out double parsedInput))
			{
				// success
				GlobalValues.Instance.ValidDouble = parsedInput;
				_teOutput.Clear();
				_teOutput.Text = ($"{GlobalValues.Instance.ValidDouble} valid input\n\nPress Reset to continue.");
			}
			else
			{
				_teOutput.Text = "Invalid input format. Please try again.\n\nPress Reset to continue.";
			}
		}
		

		
		
		
		// quick test that input is captured and directly sent to output block
		//_teOutput.Clear();
		//teOutput.Text = ($"{GlobalValues.Instance.UserInput} LineEdit input with {GlobalValues.Instance.SelectedUnits} units");
		GlobalValues.Instance.SelectedUnits = string.Empty;
		GlobalValues.Instance.UserInput = string.Empty;
		
		
		_lineEditUserInput.ReleaseFocus();
		
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
		GlobalValues.Instance.ValidDouble = 0.0;
		_lineEditUserInput.Editable = true;
		_lengthOptionSelection.Disabled = false;
		_weightOptionSelection.Disabled = false;
		_pressureOptionSelection.Disabled = false;
		_flowOptionSelection.Disabled = false;
		_submitButton.Disabled = false;
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
}