using Godot;
using System;
using UnitConversionTool.Classes;

namespace UnitConversionTool.Globals;

public partial class SaveManager : Node
{
    [Export] private AudioStreamPlayer2D _music;
    
    private const string SaveFilePath = "user://unitconversiontool.tres";
    public UserSaveData CurrentData { get; private set; }
    
    public void LogInfo(string message)
    {
        GD.Print($"[SaveManager] {message}");
    }
    
    public override async void _Ready()
    {
        LoadSaveFile();
        GD.Print("Save file loaded!");
        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        ApplySettingsToEngine();
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
        
        if (CurrentData.ThemeOption > -1)
        {
            // TODO: Still need to connect to theme options
        }

        if (CurrentData.BgmOption >= 0 && CurrentData.BgmOption < SoundController.Instance.AudioStreams.Length)
        {
            SoundController.Instance.BackgroundMusicPlayer.Stream = SoundController.Instance.AudioStreams[(int)CurrentData.BgmOption];
            
            if (CurrentData.BgmOn == true)
            {
                int bgmBusIndex = AudioServer.GetBusIndex("BGM");
                AudioServer.SetBusVolumeDb(bgmBusIndex,0.0f);
                
                SoundController.Instance.BackgroundMusicPlayer.Play();
            }
        }
        
        // with the globals reordered in project settings
        // the effects volume is now correct on app restart
        if (CurrentData.EffectsOn == false)
        {
            int sfxBusIndex = AudioServer.GetBusIndex("SFX");
            AudioServer.SetBusVolumeDb(sfxBusIndex, -100.0f);
        }
        else
        {
            int sfxBusIndex = AudioServer.GetBusIndex("SFX");
            AudioServer.SetBusVolumeDb(sfxBusIndex,0.0f);
        }
    }
}
