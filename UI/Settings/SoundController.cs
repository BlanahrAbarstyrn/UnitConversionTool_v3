using Godot;
using System;
using UnitConversionTool.Globals;

namespace UnitConversionTool.UI.Settings;

public partial class SoundController : Node
{

	[Export] private AudioStream _buttonClick;
	[Export] private AudioStream _bgMusic;
	
	[Export] private AudioStreamPlayer2D _music;
	[Export] private AudioStreamPlayer2D _effects;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SignalHub.Instance.OnMainButtonPressed += OnMainButtonPressed;
		SignalHub.Instance.OnSettingsButtonPressed += OnSettingsButtonPressed;
		SignalHub.Instance.OnAboutButtonPressed += OnAboutButtonPressed;
		SignalHub.Instance.OnChangelogButtonPressed += OnChangelogButtonPressed;
		SignalHub.Instance.OnBgmOnButtonPressed += OnBgmOnButtonPressed;
		SignalHub.Instance.OnBgmOffButtonPressed += OnBgmOffButtonPressed;
		SignalHub.Instance.OnSfxOnButtonPressed += OnSfxOnButtonPressed;
		SignalHub.Instance.OnSfxOffButtonPressed += OnSfxOffButtonPressed;
		
	}

	private void OnMainButtonPressed()
	{
		_effects.Stream = _buttonClick;
		_effects.Play();

	}
	
	private void OnSettingsButtonPressed()
	{
		_effects.Stream = _buttonClick;
		_effects.Play();
	}
	
	private void OnAboutButtonPressed()
	{
		_effects.Stream = _buttonClick;
		_effects.Play();
	}
	
	private void OnChangelogButtonPressed()
	{
		_effects.Stream = _buttonClick;
		_effects.Play();
	}
	private void OnBgmOnButtonPressed()
	{
		_effects.Stream = _buttonClick;
		_effects.Play();
		
		if (!_music.IsPlaying())
		{
			_music.Stream = _bgMusic;
			_music.Play();
		}
	}
	private void OnBgmOffButtonPressed()
	{
		_effects.Stream = _buttonClick;
		_effects.Play();

		if (_music.IsPlaying())
		{
			_music.StreamPaused = true;
		}
	}
	private void OnSfxOnButtonPressed()
	{
		int sfxBusIndex = AudioServer.GetBusIndex("SFX");
		AudioServer.SetBusVolumeDb(sfxBusIndex,0.0f);
		_effects.Stream = _buttonClick;
		_effects.Play();
	}
	private void OnSfxOffButtonPressed()
	{
		int sfxBusIndex = AudioServer.GetBusIndex("SFX");
		
		_effects.Stream = _buttonClick;
		_effects.Play();
		AudioServer.SetBusVolumeDb(sfxBusIndex, -100.0f);
	}
}
