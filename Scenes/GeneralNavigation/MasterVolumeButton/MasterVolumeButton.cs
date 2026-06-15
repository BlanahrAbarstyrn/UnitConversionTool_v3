using Godot;
using System;

namespace UnitConversionTool.Scenes.GeneralNavigation.MasterVolumeButton;
public partial class MasterVolumeButton : TextureButton
{
    [Export] private TextureButton _masterVolumeButton;

    public override void _Ready()
    {
        this.Toggled += OnButtonToggled;
    }

    private void OnButtonToggled(bool isToggledOn)
    {
        if (isToggledOn)
        {
            AudioServer.SetBusVolumeLinear(0, 0);
        }
        else
        {
            AudioServer.SetBusVolumeLinear(0, 1);
        }
    }
}
