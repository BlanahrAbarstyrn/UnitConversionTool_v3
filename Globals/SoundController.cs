using Godot;
using System.Threading.Tasks;

namespace UnitConversionTool.Globals;

public partial class SoundController : Node
{
	private SaveManager _saveManager;
	
	public static SoundController Instance { get; private set; }
	
	[Export] public AudioStream[] AudioStreams;
	[Export] public AudioStreamPlayer BackgroundMusicPlayer;
	
	[Export] private AudioStream _uiFocusAudio;
	[Export] private AudioStream _uiSelectAudio;
	[Export] private AudioStream _uiCancelAudio;
	[Export] private AudioStream _uiSuccessAudio;
	[Export] private AudioStream _uiErrorAudio;
	[Export] private AudioStream _uiGameOverAudio;
	
	private AudioStreamPlaybackPolyphonic _uiAudioPlayer;
	private AudioStreamPlaybackPolyphonic _effectsAudioPlayer;
	
	[Export] private AudioStreamPlayer _uiPlayer;
	[Export] private AudioStreamPlayer _effectsPlayer;
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		
		_saveManager = GetNode<SaveManager>("/root/SaveManager");
		CallDeferred(MethodName.InitializeBackgroundMusic);
		
		SignalHub.Instance.OnBgmOptionSelected += OnBgmOptionSelected;
	
		_uiPlayer.Play();
		_effectsPlayer.Play();
		
		// C# needs to do a cast because types don't match which wasn't needed in GDScript
		_uiAudioPlayer = _uiPlayer.GetStreamPlayback() as AudioStreamPlaybackPolyphonic;
		_effectsAudioPlayer = _effectsPlayer.GetStreamPlayback() as AudioStreamPlaybackPolyphonic;
	}
	
	private void PlaySfxAudio(AudioStream audio)
	{
		if (_effectsAudioPlayer != null)
		{
			_effectsAudioPlayer.PlayStream(audio);
		}
	}

	private void PlayUiAudio(AudioStream audio)
	{
		if (_uiAudioPlayer != null)
		{
			_uiAudioPlayer.PlayStream(audio);
		}
	}
	
	public void SetupButtonAudio(Node sceneRoot)
	{
		if (sceneRoot == null) return;
		
		foreach (Node child in sceneRoot.FindChildren("*", "BaseButton"))
		{
			if (child is BaseButton button)
			{
				button.Pressed += UiSelect;
				button.MouseEntered += UiFocusChange;
			}
		}
	}
	
	public void UiFocusChange()
	{
		Control hoveredControl = GetViewport().GetWindow().GuiGetHoveredControl();

		if (hoveredControl is BaseButton button && button.Disabled)
		{
			return;
		}
		
		PlayUiAudio(_uiFocusAudio);
	}

	public void UiSelect()
	{
		PlayUiAudio(_uiSelectAudio);
	}
	
	private void UiCancel()
	{
		PlayUiAudio(_uiCancelAudio);
	}
	
	public async void UiSuccess()
	{
		await Task.Delay(300);
		PlaySfxAudio(_uiSuccessAudio);
	}
	
	public async void UiError()
	{
		await Task.Delay(300);
		PlaySfxAudio(_uiErrorAudio);
	}
	
	public async void UiGameOver()
	{
		await Task.Delay(600);
		PlaySfxAudio(_uiGameOverAudio);
	}

	private void OnBgmOptionSelected(long index)
	{
		if ((int)index >= 0 && (int)index < AudioStreams.Length)
		{
			BackgroundMusicPlayer.Stream = AudioStreams[(int)index];
		}

		BackgroundMusicPlayer.Play();
		SignalHub.EmitRequestToggleState(true);
	}

	public void ApplyMusicByIndex(int index)
	{
		if (AudioStreams[index] == null || BackgroundMusicPlayer == null) return;
		if (index < 0 || index >= AudioStreams.Length) return;
		AudioStream selectedTrack = AudioStreams[index];
		if (selectedTrack != null)
		{
			BackgroundMusicPlayer.Stream = selectedTrack;
		}
	}
	
	private void InitializeBackgroundMusic()
	{
		if (_saveManager == null || AudioStreams == null || BackgroundMusicPlayer == null) return;

		bool isSoundOn = _saveManager.SaveProfile.MasterEnabled;

		int savedBgmIndex = _saveManager.SaveProfile.BgmIndex;

		if (savedBgmIndex >= 0 && savedBgmIndex < AudioStreams.Length)
		{
			AudioStream startupTrack = AudioStreams[savedBgmIndex];

			if (startupTrack != null)
			{
				BackgroundMusicPlayer.Stream = startupTrack;
				BackgroundMusicPlayer.Play();
				if (!isSoundOn)
				{
					AudioServer.SetBusVolumeLinear(0, 0f);
				}
			}
		}
	}
}
