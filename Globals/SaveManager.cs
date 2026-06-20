using Godot;
using UnitConversionTool.Classes;
using UnitConversionTool.Scenes.ScreenScenes.SettingsScreen.SettingsNavigation;

namespace UnitConversionTool.Globals;

public partial class SaveManager : Node
{
    public static SaveManager Instance { get; private set; }
    
    private const string ConfigFilePath = "user://unitconversiontool_config.cfg";
    
    
    public void LogInfo(string message)
    {
        GD.Print($"[SaveManager] {message}");
    }
    
    public override void _Ready()
    {
        LoadConfig();
        GD.Print("Config file loaded!");

        Instance = this;
    }

    public void SaveConfig()
    {
        var config = new ConfigFile();
        
        config.SetValue("Audio", "Master", AudioServer.GetBusVolumeLinear(0));
        config.SetValue("Audio", "HSliderBgm", AudioServer.GetBusVolumeLinear(1));
        config.SetValue("Audio", "HSliderEffects", AudioServer.GetBusVolumeLinear(2));
        config.SetValue("Audio", "HSliderUi", AudioServer.GetBusVolumeLinear(3));
        //config.SetValue("Audio", "MasterVolumeToggle", GlobalValues.Instance.MasterVolumeToggle);
        
        config.SetValue("App Theme", "ThemeOption", GlobalValues.Instance.ThemeOption);
        config.SetValue("Bgm Selection", "BgmOption", GlobalValues.Instance.BgmOption);
        
        //config.SetValue("App Stats", "Score", GlobalValues.Instance.Score);
        //config.SetValue("App Stats", "Health", GlobalValues.Instance.Health);
        
        
        LogInfo("Saving config file...");
        Error err = config.Save(ConfigFilePath);

        if (err == Error.Ok)
        {
            LogInfo("Config saved!");
        }
        else
        {
            LogInfo("Config failed!");
        }
    }

    public void LoadConfig()
    {
        var config = new ConfigFile();
        var err = config.Load(ConfigFilePath);
        if (err == Error.Ok)
        {
            LogInfo("Config file loaded!");
            AudioServer.SetBusVolumeLinear(0, (float)config.GetValue("Audio", "Master", 1.0f));
            AudioServer.SetBusVolumeLinear(1, (float)config.GetValue("Audio", "HSliderBgm", 0.2f));
            AudioServer.SetBusVolumeLinear(2, (float)config.GetValue("Audio", "HSliderEffects", 0.2f));
            AudioServer.SetBusVolumeLinear(3, (float)config.GetValue("Audio", "HSliderUi", 0.5f));
           //GlobalValues.Instance.MasterVolumeToggle = (bool)config.GetValue("Audio", "MasterVolumeToggle", false);
            
            GlobalValues.Instance.ThemeOption = (long)config.GetValue("App Theme", "ThemeOption", 0);
            GlobalValues.Instance.BgmOption = (long)config.GetValue("Bgm Selection", "BgmOption", 0);
            
            //GlobalValues.Instance.Score = (int)config.GetValue("App Stats", "Score", 0);
            //GlobalValues.Instance.Health = (int)config.GetValue("App Stats", "Health", 3);
        }
        else
        {
            LogInfo("Config failed - load default values!");
            AudioServer.SetBusVolumeLinear(0, 1.0f);
            AudioServer.SetBusVolumeLinear(1, 0.2f);
            AudioServer.SetBusVolumeLinear(2, 0.2f);
            AudioServer.SetBusVolumeLinear(3, 0.5f);
            //GlobalValues.Instance.MasterVolumeToggle = false;
            
            GlobalValues.Instance.ThemeOption = 0;
            GlobalValues.Instance.BgmOption = 0;
            
            //GlobalValues.Instance.Score = 0;
            //GlobalValues.Instance.Health = 3;
        }
    }
}
