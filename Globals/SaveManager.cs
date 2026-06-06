using Godot;
using System;
using UnitConversionTool.Classes;

namespace UnitConversionTool.Globals;

public partial class SaveManager : Node
{
    private const string SaveFilePath = "user://unitconversiontool.tres";
    
    public static SaveManager Instance { get; private set; }
    
    public UserSaveData DataHistory { get; private set; } = new ();

    public void LogInfo(string message)
    {
        GD.Print($"[SaveManager] {message}");
    }

    public override void _EnterTree()
    {
        LoadSaveFile();
    }

    public override void _ExitTree()
    {
        SaveFile();
    }

    public override void _Ready()
    {
        Instance = this;
    }

    public void LoadSaveFile()
    {
        LogInfo("Loading save file...");
        if (!ResourceLoader.Exists(SaveFilePath))
        {
            LogInfo("Save file not found!");
            return;
        }
        
        UserSaveData usd = ResourceLoader.Load<UserSaveData>(SaveFilePath);
        if (usd != null)
        {
            DataHistory = usd;
            LogInfo("Loaded save file!");
        }
        else
        {
            LogInfo("Save file not found!");
        }
    }

    public void SaveFile()
    {
        LogInfo("Saving save file...");
        Error err = ResourceSaver.Save(DataHistory, SaveFilePath);
        if (err == Error.Ok)
        {
            LogInfo("Save file saved!");
        }
        else
        {
            LogInfo("Save file failed!");
        }
    }
}
