using Godot;

namespace UnitConversionTool.Scenes.GeneralNavigation.MasterVolumeButton;
public partial class MasterVolumeButton : TextureButton
{
    [Export] private TextureButton _masterVolumeButton;

    public override void _Ready()
    {
        Toggled += OnButtonToggled;
    }

    private void OnButtonToggled(bool isToggledOn)
    {
        if (isToggledOn)
        {
            AudioServer.SetBusVolumeLinear(0, 1);
        }
        else
        {
            AudioServer.SetBusVolumeLinear(0, 0);
        }
    }
}
