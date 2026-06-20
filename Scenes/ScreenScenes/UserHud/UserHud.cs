using Godot;
using System;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.ScreenScenes.UserHud;
public partial class UserHud : CanvasLayer
{
    [Export] private MarginContainer _mC_HealthBar;
    [Export] private TextureProgressBar _hP_TPBar;

    [Export] private Label _highScore;
    [Export] private Label _level;
    

    public override void _Ready()
    {
        SignalHub.Instance.OnUserHealthChanged += OnUserHealthChanged;
        SignalHub.Instance.OnHighScoreChanged += OnHighScoreChanged;
        SignalHub.Instance.OnLevelChanged += OnLevelChanged;
    }

    private void OnUserHealthChanged(float currentHealth, float maxHealth)
    {
        var newSize = _mC_HealthBar.Size;
        
        float barValue = (currentHealth / maxHealth) * 100;
        _hP_TPBar.Value = barValue;
        newSize.X = (maxHealth * 60) + 22;
        
        _mC_HealthBar.Size = newSize;
    }

    private void OnHighScoreChanged(int highScore)
    {
        _highScore.Text = highScore.ToString("D6");
    }

    private void OnLevelChanged(string level)
    {
        _level.Text = level;
    }
}
