using Godot;
using System;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Classes;

public partial class UserSaveData : Resource
{
    [Export] public int Score { get; set; } = 0;
    [Export] public int Health { get; set; } = 3;
    [Export] public bool EffectsOn { get; set; } = true;
    [Export] public bool BgmOn { get; set; } = false;
    [Export] public long ThemeOption { get; set; } = -1;
    [Export] public long BgmOption { get; set; } = -1;
}
