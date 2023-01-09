using Godot;

public abstract class MoveHorizontal : Node2D
{
    [Export] public float Speed = 100;
    [Export] public float Width = 70;
    [Export] public float Multiplier = 9 * 3;

    public override void _PhysicsProcess(float delta)
    {
        float dist = delta * Speed;

        GlobalPosition -= new Vector2(dist * Mathf.Cos(GlobalRotation), dist * Mathf.Sin(GlobalRotation));

        if (GlobalPosition.x < -Width * 1.5f)
        {
            ManageReachedLimit();
        }
    }

    protected abstract void ManageReachedLimit();
}
