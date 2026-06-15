using Godot;
using System;
using System.Threading.Tasks;

namespace UnitConversionTool.Globals;

public partial class SoundController : Node
{
	public static SoundController Instance { get; private set; }
	
	[Export] public AudioStream[] AudioStreams;
	[Export] public AudioStreamPlayer BackgroundMusicPlayer;
	
	[Export] private AudioStream _uiFocusAudio;
	[Export] private AudioStream _uiSelectAudio;
	[Export] private AudioStream _uiCancelAudio;
	[Export] private AudioStream _uiSuccessAudio;
	[Export] private AudioStream _uiErrorAudio;
	
	private AudioStreamPlaybackPolyphonic _uiAudioPlayer;
	
	[Export] private AudioStreamPlayer _uiPlayer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		
		SignalHub.Instance.OnBgmOptionSelected += OnBgmOptionSelected;
	
		_uiPlayer.Play();
		
		// C# needs to do a cast because types don't match which wasn't needed in GDScript
		_uiAudioPlayer = _uiPlayer.GetStreamPlayback() as AudioStreamPlaybackPolyphonic;
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
		PlayUiAudio(_uiSuccessAudio);
	}
	
	public async void UiError()
	{
		await Task.Delay(300);
		PlayUiAudio(_uiErrorAudio);
	}
	
	private void OnBgmOptionSelected(long index)
	{
		if ((int)index >= 0 && (int)index < AudioStreams.Length)
		{
			BackgroundMusicPlayer.Stream = AudioStreams[(int)index];
		}
		BackgroundMusicPlayer.Play();
	}
}
