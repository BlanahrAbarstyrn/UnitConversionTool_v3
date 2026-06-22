using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.ScreenScenes.SettingsScreen;

public partial class SettingsUi : Control
{
    private SaveManager _saveManager;
    
    [Export] public OptionButton ThemeOptions;
    [Export] public OptionButton BgmOptions;
    [Export] public HSlider HSliderEffects;
    [Export] public HSlider HSliderUi;
    [Export] public HSlider HSliderBgm;
    
    
    public override void _Ready()
    {
        _saveManager = GetNode<SaveManager>("/root/SaveManager");
        
        HSliderBgm.Value = _saveManager.SaveProfile.BgmVolume;
        HSliderUi.Value = _saveManager.SaveProfile.UiVolume;
        HSliderEffects.Value = _saveManager.SaveProfile.SfxVolume;
        
        ThemeOptions.Selected = _saveManager.SaveProfile.ThemeIndex;
        BgmOptions.Selected = _saveManager.SaveProfile.BgmIndex;
        
        HSliderBgm.ValueChanged += OnHSliderBgmValueChanged;
        HSliderUi.ValueChanged += OnHSliderUiValueChanged;
        HSliderEffects.ValueChanged += OnHSliderEffectsValueChanged;

        HSliderBgm.DragEnded += (_) => _saveManager.SaveConfig();
        HSliderEffects.DragEnded += (_) => _saveManager.SaveConfig();
        HSliderUi.DragEnded += (_) => _saveManager.SaveConfig();
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
        _saveManager.SaveProfile.BgmVolume = (float)value;
    }

    private void OnHSliderUiValueChanged(double value)
    {
        SignalHub.EmitRequestToggleState(true);
        AudioServer.SetBusVolumeLinear(3, (float)value);
        SoundController.Instance.UiSelect();
        _saveManager.SaveProfile.UiVolume = (float)value;
    }

    private void OnHSliderEffectsValueChanged(double value)
    {
        SignalHub.EmitRequestToggleState(true);
        AudioServer.SetBusVolumeLinear(2, (float)value);
        SoundController.Instance.UiSuccess();
        _saveManager.SaveProfile.SfxVolume = (float)value;
    }
}

