using Godot;

public class ToolDef : Resource
{
    [Export] public ToolType ToolType;

    [Export] public Texture Icon;

    [Export] public Texture Cursor;
}