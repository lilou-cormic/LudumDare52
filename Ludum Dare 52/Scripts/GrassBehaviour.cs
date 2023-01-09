using Godot;

public class GrassBehaviour : Sprite
{
    #region Editor

    [Export] public Texture SpringSprite;

    [Export] public Texture SummerSprite;

    [Export] public Texture FallSprite;

    #endregion

    #region Initialization

    public override void _Ready()
    {
        GameManager.DayPassed += SetTexture;
    }

    #endregion

    #region Methods

    private void SetTexture()
    {
        switch (GameManager.Season)
        {
            case Season.Spring:
                Texture = SpringSprite;
                break;

            case Season.Summer:
                Texture = SummerSprite;
                break;

            case Season.Fall:
                Texture = FallSprite;
                break;
        }
    }

    #endregion
}
