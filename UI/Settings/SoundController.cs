using Godot;
using UnitConversionTool.Globals;

namespace UnitConversionTool.UI.Settings;

public partial class SoundController : Node
{

	[Export] private AudioStream _buttonClick;
	[Export] private AudioStream _bgMusic;
	
	[Export] private AudioStreamPlayer2D _music;
	[Export] private AudioStreamPlayer2D _effects;
	
	private long _selectedBgmIndex;
	private AudioStream _selectedBgmStream;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// TODO: could this be refactored by putting the signal on the base_button? 
		
		SignalHub.Instance.OnMainButtonPressed += OnMainButtonPressed;
		SignalHub.Instance.OnSettingsButtonPressed += OnSettingsButtonPressed;
		SignalHub.Instance.OnAboutButtonPressed += OnAboutButtonPressed;
		SignalHub.Instance.OnChangelogButtonPressed += OnChangelogButtonPressed;
		SignalHub.Instance.OnBgmOnButtonPressed += OnBgmOnButtonPressed;
		SignalHub.Instance.OnBgmOffButtonPressed += OnBgmOffButtonPressed;
		SignalHub.Instance.OnSfxOnButtonPressed += OnSfxOnButtonPressed;
		SignalHub.Instance.OnSfxOffButtonPressed += OnSfxOffButtonPressed;
		SignalHub.Instance.OnBgmOptionSelected += OnBgmOptionSelected;
		SignalHub.Instance.OnClearButtonPressed += OnClearButtonPressed;
		SignalHub.Instance.OnSubmitButtonPressed += OnSubmitButtonPressed;
	}

	private void OnBgmOptionSelected(long index)
	{
		_selectedBgmIndex = index;
		
		switch (index)
		{
			case 0:
				_music.Stream = GD.Load("uid://bwx1trv0cxopa") as AudioStream;
				break;
			case 1:
				_music.Stream = GD.Load("uid://truudvslg5t3") as AudioStream;
				break;
			case 2:
				_music.Stream = GD.Load("uid://dhbrnw8wkhv3h") as AudioStream;
				break;
			case 3:
				_music.Stream = GD.Load("uid://coo2fh12i4lc8") as AudioStream;
				break;
			case 4:
				_music.Stream = GD.Load("uid://223sufrqoj33") as AudioStream;
				break;
			case 5:
				_music.Stream = GD.Load("uid://dt1k1ma1p7m8b") as AudioStream;
				break;
			case 6:
				_music.Stream = GD.Load("uid://clsrscukip80d") as AudioStream;
				break;
			case 7:
				_music.Stream = GD.Load("uid://dq5ucktb6146u") as AudioStream;
				break;
			case 8:
				_music.Stream = GD.Load("uid://kejbq8j30cev") as AudioStream;
				break;
			case 9:
				_music.Stream = GD.Load("uid://kkdl054mxggi") as AudioStream;
				break;
			default:
				_music.Stream = GD.Load("uid://coo2fh12i4lc8") as AudioStream;
				break;
		}
		_selectedBgmStream = _music.Stream;
		_music.Play();
	}
	// TODO: could this be refactored by putting the signal on the base_button? 
	
	
	private void OnSubmitButtonPressed()
	{
		_effects.Stream = _buttonClick;
		_effects.Play();
	}
	
	private void OnClearButtonPressed()
	{
		_effects.Stream = _buttonClick;
		_effects.Play();
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
			_music.Stream = _selectedBgmStream;
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
