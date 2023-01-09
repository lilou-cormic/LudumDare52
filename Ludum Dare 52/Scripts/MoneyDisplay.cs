using Godot;
using PurpleCable;
using System.Collections.Generic;

public class MoneyDisplay : Label
{
    #region Data

    private List<SimpleAnimation> _animations;

    #endregion

    #region Initialization

    public override void _Ready()
    {
        Node2D parent = GetParent<Node2D>();

        _animations = new List<SimpleAnimation>()
        {
            new ScaleAnimation(parent) { Duration = 0.2f, EndLocalScale = new Vector2(parent.Scale.x * 0.9f, parent.Scale.y * 1.2f) },
            new ScaleAnimation(parent) { Delay = 0.2f, Duration = 1, EndLocalScale = parent.Scale },
        };

        GameManager.MoneyChanged += () => SetText();

        SetText();
    }

    #endregion

    #region Méthodes

    private void SetText()
    {
        Text = GameManager.Money.ToString();

        _animations.ForEach(animation => animation.Start());
    }

    public override void _PhysicsProcess(float delta)
    {
        _animations.ForEach(animation => animation.PhysicsProcess(delta));
    }

    #endregion
}
