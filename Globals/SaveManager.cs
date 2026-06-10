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
    
    public override void _Ready()
    {
        LoadSaveFile();
        GD.Print("Save file loaded!");
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
        
        //*********************** left off here trying to feed index
        // to audiostreamplayer2d to load the track and play it
        // if on is set to true
        //SoundController.OnBgmOptionSelected();
        
        // Still need to connect to theme options too
       
        
        if (CurrentData == null) return;


        if (CurrentData.ThemeOption > -1)
        {
            
        }
            
        if (CurrentData.BgmOn == true)
        {
            
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
