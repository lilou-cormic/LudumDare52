using Godot;

public class WrapHorizontal : MoveHorizontal
{
    protected override void ManageReachedLimit()
    {
        float dist = Width * Multiplier;

        GlobalPosition += new Vector2(dist * Mathf.Cos(GlobalRotation), dist * Mathf.Sin(GlobalRotation));
    }
}