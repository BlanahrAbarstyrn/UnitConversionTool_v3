using Godot;
using System;

namespace UnitConversionTool.Globals;
public partial class SettingsManager : Node
{
    public static SettingsManager Instance { get; private set; }
    
    private OptionButton _theme;

    public override void _Ready()
    {
        Instance = this;
    }
}
