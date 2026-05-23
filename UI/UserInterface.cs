using Godot;
using System;

public partial class UserInterface : Control
{
	// Called when the node enters the scene tree for the first time.
	public async override void _Ready()
	{
		await ToSignal(GetTree(), "process_frame");
		
		var window = GetWindow();
		window.MinSize = new Vector2I(360, 480); // Minimum width and height
		window.MaxSize = new Vector2I(720, 960); // Maximum and design width and height
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
