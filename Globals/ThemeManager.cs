using Godot;

namespace UnitConversionTool.Globals;
public partial class ThemeManager : Node
{
    public static ThemeManager Instance { get; private set; }
    
    private SaveManager _saveManager;

    [Export] public Theme[] Themes;

    public override void _Ready()
    {
        Instance = this;
        _saveManager = GetNode<SaveManager>("/root/SaveManager");
    }

    public void SetThemeByIndex(int index)
    {
        if (index >= 0 && index < Themes.Length && Themes[index] != null)
        {
            var window = GetWindow();
            window.Theme = Themes[index];
            _saveManager.SaveProfile.ThemeIndex = index;
            _saveManager.SaveConfig();
        }
    }
}
