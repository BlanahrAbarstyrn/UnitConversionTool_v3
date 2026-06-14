using Godot;
using UnitConversionTool.Scenes.ScreenScenes.SettingsScreen;

namespace UnitConversionTool.Classes;

public partial class UserSaveData : Resource
{
    // app default values if no persisted save data exists
    [Export] public int Score { get; set; } = 0;
    [Export] public int Health { get; set; } = 3;
    [Export] public bool EffectsOn { get; set; } = true;
    [Export] public bool BgmOn { get; set; } = false;
    [Export] public long ThemeOption { get; set; } = 0;
    [Export] public long BgmOption { get; set; } = 0;
    [Export] public double HSliderEffects { get; set; } = 0.5;
    [Export] public double HSliderBgm { get; set; } = 0.5;
}
