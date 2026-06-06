using Godot;
using System;

namespace UnitConversionTool.Classes;

public partial class UserSaveData : Resource
{
    [Export] public int Score { get; set; } = 0;
    [Export] public int Health { get; set; } = 0;
    [Export] public bool EffectsOn { get; set; } = true;
    [Export] public bool BgmOn { get; set; } = false;
    [Export] public long ThemeOption { get; set; } = -1;
    [Export] public long BgmOption { get; set; } = -1;

}
