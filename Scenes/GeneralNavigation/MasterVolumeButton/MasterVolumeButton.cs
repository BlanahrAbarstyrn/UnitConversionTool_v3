using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.GeneralNavigation.MasterVolumeButton;
public partial class MasterVolumeButton : TextureButton
{
    private SaveManager _saveManager;
    
    [Export] public TextureButton MasterVolume;

    public override void _Ready()
    {
        _saveManager = GetNode<SaveManager>("/root/SaveManager");
        Toggled += OnButtonToggled;
        SignalHub.Instance.RequestToggleState += OnButtonToggled;
        MasterVolume.ButtonPressed = _saveManager.SaveProfile.MasterEnabled;
    }

    private void OnButtonToggled(bool isToggledOn)
    {
        if (isToggledOn)
        {
            AudioServer.SetBusVolumeLinear(0, 1);
            MasterVolume.ButtonPressed = true;
            _saveManager.SaveProfile.MasterEnabled = true;
            _saveManager.SaveConfig();
        }
        else
        {
            AudioServer.SetBusVolumeLinear(0, 0);
            MasterVolume.ButtonPressed = false;
            _saveManager.SaveProfile.MasterEnabled = false;
            _saveManager.SaveConfig();
        }
    }
}
