using Godot;
using System;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes.ScreenScenes.UserHud;
public partial class UserHud : CanvasLayer
{
    private SaveManager _saveManager;
    
    [Export] private MarginContainer _mC_HealthBar;
    [Export] private TextureProgressBar _hP_TPBar;

    [Export] private Label _highScore;
    [Export] private Label _level;
    

    public override void _Ready()
    {
        SignalHub.Instance.OnUserHealthChanged += OnUserHealthChanged;
        SignalHub.Instance.OnHighScoreChanged += OnHighScoreChanged;
        SignalHub.Instance.OnLevelChanged += OnLevelChanged;
        
        _saveManager = GetNode<SaveManager>("/root/SaveManager");
        OnUserHealthChanged(_saveManager.SaveProfile.Health, 3);
        OnHighScoreChanged(_saveManager.SaveProfile.HighScore);
        OnLevelChanged(_saveManager.SaveProfile.Level);
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
        if (_highScore.Text != highScore.ToString())
        {
            _highScore.Text = highScore.ToString("D6");
        }
    }

    private void OnLevelChanged(string level)
    {
        if (_level.Text != level)
        {
            _level.Text = level;
            if (_saveManager != null)
            {
                _saveManager.SaveProfile.Level = level;
                _saveManager.SaveConfig();
            }
        }
    }
}
