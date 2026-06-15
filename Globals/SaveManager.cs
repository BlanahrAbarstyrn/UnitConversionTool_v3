using Godot;
using UnitConversionTool.Classes;
using UnitConversionTool.Scenes.ScreenScenes.SettingsScreen.SettingsNavigation;

namespace UnitConversionTool.Globals;

public partial class SaveManager : Node
{
    public static SaveManager Instance { get; private set; }
    
    [Export] private AudioStreamPlayer2D _music;
    
    private const string SaveFilePath = "user://unitconversiontool.tres";
    private const string ConfigFilePath = "user://unitconversiontool_config.cfg";
    
    public UserSaveData CurrentData { get; private set; }
    
    public void LogInfo(string message)
    {
        GD.Print($"[SaveManager] {message}");
    }
    
    public override async void _Ready()
    {
        LoadSaveFile();
        GD.Print("Save file loaded!");
        LoadConfig();
        GD.Print("Config file loaded!");
        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        ApplySettingsToEngine();

        Instance = this;
    }

    public void LoadSaveFile()
    {
        if (ResourceLoader.Exists(SaveFilePath))
        {
            // load existing file
            CurrentData = ResourceLoader.Load<UserSaveData>(SaveFilePath);
        }
        else
        {
            // create new instance with defaults if file doesn't exist
            CurrentData = new UserSaveData();
            SaveFile();
        }
    }

    public void SaveConfig()
    {
        var config = new ConfigFile();
  
        config.SetValue("App Stats", "Score", GlobalValues.Instance.Score);
        config.SetValue("App Stats", "Health", GlobalValues.Instance.Health);
        
        config.SetValue("Audio", "HSliderBgm", AudioServer.GetBusVolumeLinear(1));
        config.SetValue("Audio", "HSliderEffects", AudioServer.GetBusVolumeLinear(2));
        
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
            AudioServer.SetBusVolumeLinear(1, (float)config.GetValue("Audio", "HSliderBgm", 0.2f));
            AudioServer.SetBusVolumeLinear(2, (float)config.GetValue("Audio", "HSliderEffects", 0.2f));
        }
        else
        {
            LogInfo("Config failed - load default values!");
            AudioServer.SetBusVolumeLinear(1, 0.5f);
            AudioServer.SetBusVolumeLinear(2, 0.5f);
        }
        
    }
    
    public void SaveFile()
    {
        LogInfo("Saving save file...");
        Error err = ResourceSaver.Save(CurrentData, SaveFilePath);

        if (err == Error.Ok)
        {
            LogInfo("Save file saved!");
        }
        else
        {
            LogInfo("Save file failed!");
        }
    }

    public void ApplySettingsToEngine()
    {
        if (CurrentData == null) return;
        
        if (CurrentData.ThemeOption > -1 && CurrentData.ThemeOption < ThemeManager.Instance.Themes.Length)
        {
            ThemeManager.Instance.SetThemeByIndex((int)CurrentData.ThemeOption);
        }
        else
        {
            ThemeManager.Instance.SetThemeByIndex(0);
        }

        if (CurrentData.BgmOption >= 0 && CurrentData.BgmOption < SoundController.Instance.AudioStreams.Length)
        {
            SoundController.Instance.BackgroundMusicPlayer.Stream = SoundController.Instance.AudioStreams[(int)CurrentData.BgmOption];
            
            int bgmBusIndex = AudioServer.GetBusIndex("BGM");
            //AudioServer.SetBusVolumeDb(bgmBusIndex, (float)CurrentData.HSliderBgm);
                
            SoundController.Instance.BackgroundMusicPlayer.Play();
            
        }
        
        //int sfxBusIndex = AudioServer.GetBusIndex("SFX");
        //AudioServer.SetBusVolumeLinear(sfxBusIndex, (float)CurrentData.HSliderEffects);
    }
}
