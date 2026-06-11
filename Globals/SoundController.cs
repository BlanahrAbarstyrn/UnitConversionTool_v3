using Godot;

namespace UnitConversionTool.Globals;

public partial class SoundController : Node
{
	public static SoundController Instance { get; private set; }
	
	[Export] private AudioStream _buttonClick;
	[Export] public AudioStream[] AudioStreams;

	[Export] public AudioStreamPlayer BackgroundMusicPlayer;
	[Export] private AudioStreamPlayer2D _effects;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		
		SignalHub.Instance.OnAboutButtonPressed += OnAboutButtonPressed;
		SignalHub.Instance.OnBgmOffButtonPressed += OnBgmOffButtonPressed;
		SignalHub.Instance.OnBgmOnButtonPressed += OnBgmOnButtonPressed;
		SignalHub.Instance.OnBgmOptionSelected += OnBgmOptionSelected;
		SignalHub.Instance.OnChangelogButtonPressed += OnChangelogButtonPressed;
		SignalHub.Instance.OnClearButtonPressed += OnClearButtonPressed;
		SignalHub.Instance.OnMainButtonPressed += OnMainButtonPressed;
		SignalHub.Instance.OnSettingsButtonPressed += OnSettingsButtonPressed;
		SignalHub.Instance.OnSfxOffButtonPressed += OnSfxOffButtonPressed;
		SignalHub.Instance.OnSfxOnButtonPressed += OnSfxOnButtonPressed;
		SignalHub.Instance.OnSubmitButtonPressed += OnSubmitButtonPressed;
	}

	private void OnBgmOptionSelected(long index)
	{
		if ((int)index >= 0 && (int)index < AudioStreams.Length)
		{
			BackgroundMusicPlayer.Stream = AudioStreams[(int)index];
		}
		BackgroundMusicPlayer.Play();
	}
	
	private void OnAboutButtonPressed()
	{
		_effects.Stream = _buttonClick;
		_effects.Play();
	}
	
	private void OnBgmOffButtonPressed()
	{
		_effects.Stream = _buttonClick;
		_effects.Play();
		
		int bgmBusIndex = AudioServer.GetBusIndex("BGM");
		AudioServer.SetBusVolumeDb(bgmBusIndex, -100.0f);
	}
	
	private void OnBgmOnButtonPressed()
	{
		_effects.Stream = _buttonClick;
		_effects.Play();
		
		if (!BackgroundMusicPlayer.IsPlaying())
		{
			BackgroundMusicPlayer.Play();
		}
		
		int bgmBusIndex = AudioServer.GetBusIndex("BGM");
		AudioServer.SetBusVolumeDb(bgmBusIndex,0.0f);
		
	}
	
	private void OnChangelogButtonPressed()
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

	private void OnSfxOffButtonPressed()
	{
		int sfxBusIndex = AudioServer.GetBusIndex("SFX");
		
		_effects.Stream = _buttonClick;
		_effects.Play();
		AudioServer.SetBusVolumeDb(sfxBusIndex, -100.0f);
	}
	
	private void OnSfxOnButtonPressed()
	{
		int sfxBusIndex = AudioServer.GetBusIndex("SFX");
		AudioServer.SetBusVolumeDb(sfxBusIndex,0.0f);
		_effects.Stream = _buttonClick;
		_effects.Play();
	}
		
	private void OnSubmitButtonPressed()
	{
		_effects.Stream = _buttonClick;
		_effects.Play();
	}
}
