using System;

namespace UnitConversionTool.Classes;

[Serializable]
public class AppData
{
    // Audio Settings
    public float MasterVolume { get; set; } = 1.0f;
    public float BgmVolume { get; set; } = 0.2f;
    public float SfxVolume { get; set; } = 0.5f;
    public float UiVolume { get; set; } = 1.0f;
    public bool MasterEnabled { get; set; } = false;
    
    // Cosmetics
    public int ThemeIndex { get; set; } = 0;
    public int BgmIndex { get; set; } = 0;
    
    // User Progression
    public int HighScore { get; set; } = 0;
    public int Health { get; set; } = 3;
    public string Level { get; set; } = "Rookie";
}