using Godot;
using System;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Classes;

public partial class UserSaveData : Resource
{
    [Export] public int Score = 0;
    [Export] public int Health = 3;
    [Export] public bool EffectsOn = true;
    [Export] public bool BgmOn = false;
    [Export] public long ThemeOption = -1;
    [Export] public long BgmOption = -1;
}
