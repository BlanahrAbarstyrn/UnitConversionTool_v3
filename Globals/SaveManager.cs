using Godot;
using System;
using UnitConversionTool.Classes;

namespace UnitConversionTool.Globals;

public partial class SaveManager : Node
{
    private const string SaveFilePath = "user://unitconversiontool.tres";
    public UserSaveData CurrentData { get; private set; }
    
    public void LogInfo(string message)
    {
        GD.Print($"[SaveManager] {message}");
    }
    
    public override void _Ready()
    {
        //Instance = this;
        LoadSaveFile();
        GD.Print("Save file loaded!");
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

    public void ApplySettings()
    {
        
    }
}
