using Godot;
using System;
using UnitConversionTool.Globals;

namespace UnitConversionTool.UI.ScreenScenes;
public partial class TabBar : Godot.TabBar
{
	[Export] private TabBar _tabBarOption;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//_tabBarOption. += OnTabBarOptionSelected;
	}

	private void OnTabBarOptionSelected(int tab)
	{
		//SignalHub.EmitOnTabBarOptionSelected(tab);
	}
}
