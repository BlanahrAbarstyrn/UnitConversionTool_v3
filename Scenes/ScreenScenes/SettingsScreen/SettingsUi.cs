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
    [Export] public SfxOffTextureButton SfxOff;
    [Export] public SfxOnTextureButton SfxOn;
    [Export] public BgmOffTextureButton BgmOff;
    [Export] public BgmOnTextureButton BgmOn;
    
    public override void _Ready()
    {
        // making UI visual changes only on app startup
        // actual settings triggers happening in SaveManager
        
        var saveManager = GetNode<SaveManager>("/root/SaveManager");
        var loadedData = saveManager.CurrentData;

        if (loadedData == null) return;

        ThemeOptions.Selected = (int)loadedData.ThemeOption;
        
        BgmOptions.Selected = (int)loadedData.BgmOption;
        
        
        //HSliderBgm.Value = AudioServer.GetBusVolumeLinear(1);
        HSliderBgm.Value = (float)loadedData.HSliderBgm;
        AudioServer.SetBusVolumeLinear(1, (float)HSliderBgm.Value);
        
        
        //HSliderEffects.Value = AudioServer.GetBusVolumeLinear(2);
        HSliderEffects.Value = (float)loadedData.HSliderEffects;
        AudioServer.SetBusVolumeLinear(2, (float)HSliderEffects.Value);
 
        HSliderBgm.ValueChanged += OnHSliderBgmValueChanged;
        HSliderEffects.ValueChanged += OnHSliderEffectsValueChanged;
        
        SignalHub.Instance.OnBgmOffButtonPressed += OnBgmOffButtonPressed;
        SignalHub.Instance.OnBgmOnButtonPressed += OnBgmOnButtonPressed;
        SignalHub.Instance.OnSfxOffButtonPressed += OnSfxOffButtonPressed;
        SignalHub.Instance.OnSfxOnButtonPressed += OnSfxOnButtonPressed;
    }
    
    // making UI visual changes only on app startup
    // actual settings triggers happening in SaveManager
    
    private void OnBgmOffButtonPressed()
    {
        HSliderBgm.Value = 0;
    }

    private void OnBgmOnButtonPressed()
    {
        HSliderBgm.Value = 0.5;
    }

    private void OnSfxOffButtonPressed()
    {
        HSliderEffects.Value = 0;
    }

    private void OnSfxOnButtonPressed()
    {
        HSliderEffects.Value = 0.5;
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

