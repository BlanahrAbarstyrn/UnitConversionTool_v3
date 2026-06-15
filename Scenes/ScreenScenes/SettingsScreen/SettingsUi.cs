using Godot;
using UnitConversionTool.Globals;
using UnitConversionTool.Scenes.ScreenScenes.SettingsScreen.SettingsNavigation;

namespace UnitConversionTool.Scenes.ScreenScenes.SettingsScreen;

public partial class SettingsUi : Control
{
    [Export] public OptionButton ThemeOptions;
    [Export] public OptionButton BgmOptions;
    [Export] public HSlider HSliderEffects;
    [Export] public HSlider HSliderBgm;
    
    
    public override void _Ready()
    {
     
        var saveManager = GetNode<SaveManager>("/root/SaveManager");
        var loadedData = saveManager.CurrentData;
        
        AudioServer.SetBusVolumeLinear(1, 0.2f);
        HSliderBgm.Value = 0.2;
        AudioServer.SetBusVolumeLinear(2, 0.7f);
        HSliderEffects.Value = 0.7;

        if (loadedData == null) return;

        ThemeOptions.Selected = (int)loadedData.ThemeOption;
        
        BgmOptions.Selected = (int)loadedData.BgmOption;
        
        

        //AudioServer.SetBusVolumeLinear(1, (float)HSliderBgm.Value);
        
        

        //AudioServer.SetBusVolumeLinear(2, (float)HSliderEffects.Value);
 
        HSliderBgm.ValueChanged += OnHSliderBgmValueChanged;
        HSliderEffects.ValueChanged += OnHSliderEffectsValueChanged;
        

        
    }
    

    
    // OnHSliders do adjust volumes in addition to updating visual
    private void OnHSliderBgmValueChanged(double value)
    {
        AudioServer.SetBusVolumeLinear(1, (float)value);
    }

    private void OnHSliderEffectsValueChanged(double value)
    {
        AudioServer.SetBusVolumeLinear(2, (float)value);
        SoundController.Instance.UiSelect();
    }
    
}

