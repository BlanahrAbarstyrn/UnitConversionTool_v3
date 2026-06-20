using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.ScreenScenes.SettingsScreen;

public partial class SettingsUi : Control
{
    [Export] public OptionButton ThemeOptions;
    [Export] public OptionButton BgmOptions;
    [Export] public HSlider HSliderEffects;
    [Export] public HSlider HSliderUi;
    [Export] public HSlider HSliderBgm;
    
    
    public override void _Ready()
    {
        AudioServer.SetBusVolumeLinear(1, 0.2f);
        HSliderBgm.Value = 0.2;
        AudioServer.SetBusVolumeLinear(3, 1.0f);
        HSliderUi.Value = 1.0;
        AudioServer.SetBusVolumeLinear(2, 0.7f);
        HSliderEffects.Value = 0.7;
        
        HSliderBgm.ValueChanged += OnHSliderBgmValueChanged;
        HSliderUi.ValueChanged += OnHSliderUiValueChanged;
        HSliderEffects.ValueChanged += OnHSliderEffectsValueChanged;
    }

    public override void _ExitTree()
    {
        HSliderBgm.ValueChanged -= OnHSliderBgmValueChanged;
        HSliderUi.ValueChanged -= OnHSliderUiValueChanged;
        HSliderEffects.ValueChanged -= OnHSliderEffectsValueChanged;
    }
    
    // OnHSliders do adjust volumes in addition to updating visual
    private void OnHSliderBgmValueChanged(double value)
    {
        SignalHub.EmitRequestToggleState(true);
        AudioServer.SetBusVolumeLinear(1, (float)value);
    }

    private void OnHSliderUiValueChanged(double value)
    {
        SignalHub.EmitRequestToggleState(true);
        AudioServer.SetBusVolumeLinear(3, (float)value);
        SoundController.Instance.UiSelect();
    }

    private void OnHSliderEffectsValueChanged(double value)
    {
        SignalHub.EmitRequestToggleState(true);
        AudioServer.SetBusVolumeLinear(2, (float)value);
        SoundController.Instance.UiSuccess();
    }
    
}

