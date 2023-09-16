using Godot;
using PurpleCable;

public class CoinBehaviour : Sprite
{
    #region Data

    private MoveAnimation _moveAnimation;

    #endregion

    #region Initialization

    public override void _Ready()
    {
        _moveAnimation = new MoveAnimation(this) { Duration = 0.5f, EndGlobalPosition = new Vector2(793, 82), IsLine = true };
        _moveAnimation.Start();
    }

    #endregion

    #region Methods

    public override void _PhysicsProcess(float delta)
    {
        _moveAnimation.PhysicsProcess(delta);

        if (_moveAnimation.IsDoneAnimating)
            QueueFree();
    }

    #endregion
}
