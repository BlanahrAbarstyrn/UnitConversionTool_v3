using Godot;
using System;
using UnitConversionTool.UI.Settings;


namespace UnitConversionTool.Classes;
public partial class ConfigFile : Resource
{
    [Export] private string _themeOption;
    [Export] private bool _bgmOn;
    [Export] private bool _effectOn;
    [Export] private string _musicOption;

    public string ThemeOption
    {
        get
        {
            return _themeOption;
        }
        set
        {
            _themeOption = value;
        }
    }

    public bool BgmOn
    {
        get
        {
            return _bgmOn;
        }
        set
        {
            _bgmOn = value;
        }
    }
    
    public bool EffectOn
    {
        get
        {
            return _effectOn;
        }
        set
        {
            _effectOn = value;
        }
    }

    public string MusicOption
    {
        get
        {
            return _musicOption;
        }
        set
        {
            _musicOption = value;
        }
    }
}
