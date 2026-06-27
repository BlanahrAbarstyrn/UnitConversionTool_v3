using Godot;
using UnitConversionTool.Classes;

namespace UnitConversionTool.Globals;

public partial class SaveManager : Node
{
    private const string ConfigFilePath = "user://appdata.cfg";
    
    // Holds data temporarily after disk read, or packages data before disk write
    public AppData SaveProfile { get; private set; } = new AppData();
    
    // References specialized controller nodes
    private ThemeManager _themeManager;
    private SoundController _soundController;
    
    public override void _Ready()
    {
        _themeManager = GetNode<ThemeManager>("/root/ThemeManager");
        _soundController = GetNode<SoundController>("/root/SoundController");
        
        LoadConfig();
    }

    public void SaveConfig()
    {
        var config = new ConfigFile();
        
        // Audio
        config.SetValue("Audio", "MasterVolume", SaveProfile.MasterVolume);
        config.SetValue("Audio", "BgmVolume", SaveProfile.BgmVolume);
        config.SetValue("Audio", "SfxVolume", SaveProfile.SfxVolume);
        config.SetValue("Audio", "UiVolume", SaveProfile.UiVolume);
        config.SetValue("Audio", "MasterEnabled", SaveProfile.MasterEnabled);
        
        // Cosmetics
        config.SetValue("Cosmetics", "ThemeIndex", SaveProfile.ThemeIndex);
        config.SetValue("Cosmetics", "BgmIndex", SaveProfile.BgmIndex);
        
        // Progression
        config.SetValue("Progression", "HighScore", SaveProfile.HighScore);
        config.SetValue("Progression", "Health", SaveProfile.Health);
        config.SetValue("Progression", "Level", SaveProfile.Level);
        
        config.Save(ConfigFilePath);
    }

    public void LoadConfig()
    {
        var config = new ConfigFile();
        var err = config.Load(ConfigFilePath);
        if (err != Error.Ok)
        {
            ApplySystemSettings();
            return;
        }
        
        SaveProfile.MasterVolume = (float)config.GetValue("Audio", "MasterVolume", 1.0f);
        SaveProfile.BgmVolume = (float)config.GetValue("Audio", "BgmVolume", 0.2f);
        SaveProfile.SfxVolume = (float)config.GetValue("Audio", "SfxVolume", 0.5f);
        SaveProfile.UiVolume = (float)config.GetValue("Audio", "UiVolume", 1.0f);
        
        SaveProfile.BgmIndex = (int)config.GetValue("Cosmetics", "BgmIndex", 0);
        
        // These values will wait for Hud or MasterVolumeButton to call for them
        SaveProfile.MasterEnabled = (bool)config.GetValue("Audio", "MasterEnabled", false);
        SaveProfile.ThemeIndex = (int)config.GetValue("Cosmetics", "ThemeIndex", 0);
        SaveProfile.HighScore = (int)config.GetValue("Progression", "HighScore", 0);
        SaveProfile.Health = (int)config.GetValue("Progression", "Health", 3);
        SaveProfile.Level = (string)config.GetValue("Progression", "Level", "Untrained");

        ApplySystemSettings();
    }

    private void ApplySystemSettings()
    {
        // Audio Bus
        AudioServer.SetBusVolumeLinear(AudioServer.GetBusIndex("Master"), SaveProfile.MasterVolume);
        AudioServer.SetBusVolumeLinear(AudioServer.GetBusIndex("BGM"), SaveProfile.BgmVolume);
        AudioServer.SetBusVolumeLinear(AudioServer.GetBusIndex("SFX"), SaveProfile.SfxVolume);
        AudioServer.SetBusVolumeLinear(AudioServer.GetBusIndex("UI"), SaveProfile.UiVolume);
        
        _themeManager?.SetThemeByIndex(SaveProfile.ThemeIndex);
        _soundController?.ApplyMusicByIndex(SaveProfile.BgmIndex);
    }
}