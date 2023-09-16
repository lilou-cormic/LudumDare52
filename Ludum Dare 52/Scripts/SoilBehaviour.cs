using Godot;
using System;

public class SoilBehaviour : Sprite
{
    #region Editor

    [Export] public Texture DrySoilSprite;

    [Export] public Texture WetSoilSprite;

    [Export] public bool NeedsPlowing;

    #endregion

    #region Data

    private Sprite _HighlightSprite;

    #endregion

    #region Events

    public event Action StateChanged;

    #endregion

    #region Initialization

    public override void _Ready()
    {
        _HighlightSprite = GetChild<Sprite>(0);
        _HighlightSprite.Visible = false;

        GameManager.DayPassed += DryUp;
    }

    #endregion

    #region Methods

    public void SetHighlight(bool highlight)
    {
        if (NeedsPlowing && GameManager.CurrentToolType != ToolType.Shovel)
            highlight = false;

        _HighlightSprite.Visible = highlight;
    }

    public void Plow()
    {
        NeedsPlowing = false;
        DryUp();

        StateChanged?.Invoke();
    }

    public void Water()
    {
        if (!NeedsPlowing)
            Texture = WetSoilSprite;
    }

    private void DryUp()
    {
        if (!NeedsPlowing)
            Texture = DrySoilSprite;
    }

    #endregion
}
