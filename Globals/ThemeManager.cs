using Godot;

namespace UnitConversionTool.Globals;
public partial class ThemeManager : Node
{
    public static ThemeManager Instance { get; private set; }

    [Export] public Theme[] Themes;

    public override void _Ready()
    {
        Instance = this;
    }

    public void SetThemeByIndex(int index)
    {
        if (index >= 0 && index < Themes.Length && Themes[index] != null)
        {
            var window = GetWindow();
            window.Theme = Themes[index];
        }
    }
}
