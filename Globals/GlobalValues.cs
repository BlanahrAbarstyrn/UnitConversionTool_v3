using Godot;
using System;

namespace UnitConversionTool.Globals;
public partial class GlobalValues : Node
{
    public static GlobalValues Instance { get; private set; }
    
    public string SelectedUnits { get; set; } = "";

    public override void _Ready()
    {
        Instance = this;
    }
    
}
