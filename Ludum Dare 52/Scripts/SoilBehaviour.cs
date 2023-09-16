using Godot;
using System;

public class SoilBehaviour : Sprite
{
    #region Editor

    [Export] public Texture RawSoilSprite;

    [Export] public Texture DrySoilSprite;

    [Export] public Texture WetSoilSprite;

    [Export] public SoilState SoilState;

    #endregion

    #region Data

    private Sprite _HighlightSprite;

    public bool IsPlantable => SoilState == SoilState.Dry || SoilState == SoilState.Wet;

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

        SetTexture();
    }

    #endregion

    #region Methods

    private void SetTexture()
    {
        switch (SoilState)
        {
            case SoilState.Grass:
                Texture = null;
                break;

            case SoilState.Raw:
                Texture = RawSoilSprite;
                break;

            case SoilState.Dry:
                Texture = DrySoilSprite;
                break;

            case SoilState.Wet:
                Texture = WetSoilSprite;
                break;
        }
    }

    public void SetHighlight(bool highlight)
    {
        if (SoilState == SoilState.Grass && GameManager.CurrentToolType != ToolType.Shovel)
            highlight = false;

        _HighlightSprite.Visible = highlight;
    }

    public void Shovel()
    {
        SoilState = SoilState.Raw;
        SetTexture();

        StateChanged?.Invoke();
    }

    public void Plow()
    {
        if (SoilState == SoilState.Raw)
        {
            SoilState = SoilState.Dry;
            SetTexture();

            StateChanged?.Invoke();
        }
    }

    public void Water()
    {
        if (SoilState == SoilState.Dry)
        {
            SoilState = SoilState.Wet;
            SetTexture();

            StateChanged?.Invoke();
        }
    }

    private void DryUp()
    {
        if (SoilState == SoilState.Wet)
        {
            SoilState = SoilState.Dry;
            SetTexture();

            StateChanged?.Invoke();
        }
    }

    #endregion
}
