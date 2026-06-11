using Godot;

namespace UnitConversionTool.Globals;

public partial class AudioCleanup : Node
{
    public override void _ExitTree()
    {
        // Audio Players running when app quits is causing a memory leak
        // This Global Script should stop all players
        // It is registered as an Autoload
        // Can also be added to a "Quit" button if one is added later
        
        // Retrieve all nodes in the "Audio4Cleanup" group
        var players = GetTree().GetNodesInGroup("Audio4Cleanup");

        foreach (var node in players)
        {
            if (node is AudioStreamPlayer player)
            {
                player.Stop();
            }

            if (node is AudioStreamPlayer2D player2D)
            {
                player2D.Stop();
            }
        }
        
        GetTree().Quit();
    }
}

