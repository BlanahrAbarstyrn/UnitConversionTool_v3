using Godot;

namespace UnitConversionTool.Globals;
public partial class GlobalValues : Node
{
    public static GlobalValues Instance { get; private set; }
    
    public long ThemeOption { get; set; }
    
    public long BgmOption { get; set; }
    
    public string SelectedUnits { get; set; } = "";
    
    public string UserInput { get; set; } = "";
    
    public bool HasError { get; set; } = false;
    public double ValidDouble  { get; set; } = 0;
    
    public override void _Ready()
    {
        Instance = this;
    }
    
}
