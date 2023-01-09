using Godot;

public class ToolsRes : Node2D
{
    #region Initialization

    public override void _Ready()
    {
        Tools.SetDefs(new Tools.ToolTypeResourceDictionary(GetNode<ResourceNode2D>("ToolsRes").LoadAll<ToolDef>()));
    }

    #endregion
}