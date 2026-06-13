using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.ScreenScenes.SettingsScreen;

public partial class SettingsUi : Control
{
    [Export] public OptionButton ThemeOptions;
    [Export] public OptionButton BgmOptions;
    
    public override void _Ready()
    {
        // making UI visual changes only on app startup
        // actual settings triggers happening in SaveManager
        
        var saveManager = GetNode<SaveManager>("/root/SaveManager");
        var loadedData = saveManager.CurrentData;

        if (loadedData == null) return;

        ThemeOptions.Selected = (int)loadedData.ThemeOption;
        
        BgmOptions.Selected = (int)loadedData.BgmOption;
    }
}

