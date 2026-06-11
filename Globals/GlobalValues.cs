using Godot;

namespace UnitConversionTool.Globals;
public partial class GlobalValues : Node
{
    public static GlobalValues Instance { get; private set; }
    
    public int Score { get; set; } = 0;

    private const int MaxHealth = 3;
    
    public int Health = MaxHealth;
    
    public string SelectedUnits { get; set; } = "";
    
    public string UserInput { get; set; } = "";
    
    public bool HasError { get; set; } = false;
    public double ValidDouble  { get; set; } = 0;
    
    public override void _Ready()
    {
        Instance = this;
    }

    public void ResetHealth()
    {
        Health = MaxHealth;
    }
}
