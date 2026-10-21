using System.Collections.Generic;
using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.ScreenScenes.SettingsScreen;

public partial class SettingsUi : Control
{
    private SaveManager _saveManager;
    
    [Export] public OptionButton ThemeOptions;
    [Export] public OptionButton AppSizeOptions;
    [Export] public OptionButton BgmOptions;
    [Export] public HSlider HSliderEffects;
    [Export] public HSlider HSliderUi;
    [Export] public HSlider HSliderBgm;
    //[Export] private Button _mainButton;

    private readonly List<Vector2I> _screenResolutions = new()
    {
        new Vector2I(720, 960),
        new Vector2I(900, 1200),
        new Vector2I(1080, 1440),
        new Vector2I(1440, 1920),
        new Vector2I(540, 720),
    };
    
    
    public override void _Ready()
    {
        _saveManager = GetNode<SaveManager>("/root/SaveManager");

        SetupAppSizeOptions();
        GetTree().Root.SizeChanged += OnRootSizeChanged;
        
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

    private void SetupAppSizeOptions()
    {
        foreach (Vector2I size in _screenResolutions)
        {
            AppSizeOptions.AddItem($"{size.X} x {size.Y}");
        }
        
        // Select the preset matching the window's current size, if on list
        Vector2I currentSize = DisplayServer.WindowGetSize();
        int selected = _screenResolutions.IndexOf(currentSize);

        AppSizeOptions.ItemSelected += OnResolutionSelected;
    }

    private void OnRootSizeChanged()
    {
        GD.Print($"Root viewport resized: {GetTree().Root.Size}");
    }
    
    private void OnResolutionSelected(long selectedIndex)
    {
        GD.Print($"Window: {DisplayServer.WindowGetSize()}");
        GD.Print($"Root viewport: {GetTree().Root.Size}");
        DisplayServer.WindowSetSize(_screenResolutions[(int) selectedIndex]);
        GD.Print($"Window: {DisplayServer.WindowGetSize()}");
        GD.Print($"Root viewport: {GetTree().Root.Size}");
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

