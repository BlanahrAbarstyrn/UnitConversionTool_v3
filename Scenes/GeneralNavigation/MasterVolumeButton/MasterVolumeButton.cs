using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.GeneralNavigation.MasterVolumeButton;
public partial class MasterVolumeButton : TextureButton
{
    [Export] public TextureButton MasterVolume;

    public override void _Ready()
    {
        Toggled += OnButtonToggled;
        SignalHub.Instance.RequestToggleState += OnButtonToggled;
    }

    private void OnButtonToggled(bool isToggledOn)
    {
        if (isToggledOn)
        {
            AudioServer.SetBusVolumeLinear(0, 1);
            MasterVolume.ButtonPressed = true;
        }
        else
        {
            AudioServer.SetBusVolumeLinear(0, 0);
            MasterVolume.ButtonPressed = false;
        }
    }
}
