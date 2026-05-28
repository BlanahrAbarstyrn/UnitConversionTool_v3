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
		// quick test that input is captured and directly sent to output block
		_teOutput.Clear();
		_teOutput.Text = ($"{input} LineEdit input with {GlobalValues.Instance.SelectedUnits} units");
		GlobalValues.Instance.SelectedUnits = string.Empty;
		
		
		_lineEditUserInput.ReleaseFocus();
		
	}
	
	private void OnClearButtonPressed()
	{
		OnTabBarClicked(0);
		_tabBar.SetCurrentTab(0);
		_teOutput.Text = "Converted units will appear here";
		_lineEditUserInput.Clear();
		GlobalValues.Instance.SelectedUnits = string.Empty;
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
	
	/*
	private void OnSubmitButtonPressed()
	{
		// TODO
		// read user input from LineEditUserInput
		if (_tabBar.CurrentTab == 0 && _lengthOptionSelection.Selected == 0)
		{
			// try / except - run input through parser
		}
		else
		{
			// try / except - can be turned into a float
		}
		
		// if successful use key, value to run through base_unit dictionary
		
		// send output to TEoutput
		
	}
	*/
	
}