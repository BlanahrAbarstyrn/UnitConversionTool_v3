using Godot;
using System;
using UnitConversionTool.Globals;

namespace UnitConversionTool.Scenes;

public partial class GameOverCamera : Camera2D
{
    [Export] private double _shakeAmount = 5.0f;
    [Export] private double _shakeTime = 0.3f;

    public override void _Ready()
    {
        SignalHub.Instance.OnGameOver += OnGameOver;
        SetProcess(false);
    }

    public override void _ExitTree()
    {
        SignalHub.Instance.OnGameOver -= OnGameOver;
    }

    private async void OnGameOver(bool gameOver)
    {
        if (!gameOver) return;
        SoundController.Instance.UiGameOver();
        SetProcess(true);
        
        await ToSignal(GetTree().CreateTimer(_shakeTime), Timer.SignalName.Timeout);
        SetProcess(false);
        Offset = Vector2.Zero;
    }

    public override void _Process(double delta)
    {
        Offset = new Vector2(
            (float)GD.RandRange(-_shakeAmount, _shakeAmount),
            (float)GD.RandRange(-_shakeAmount, _shakeAmount)
        );
    }

}    