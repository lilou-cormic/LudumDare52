using Godot;

public class SoilBehaviour : Sprite
{
    #region Editor

    [Export] public Texture DrySoilSprite;

    [Export] public Texture WetSoilSprite;

    #endregion

    #region Data

    private Sprite _HighlightSprite;

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
        _HighlightSprite.Visible = highlight;
    }

    public void Water()
    {
        Texture = WetSoilSprite;
    }

    private void DryUp()
    {
        Texture = DrySoilSprite;
    }

    #endregion
}
