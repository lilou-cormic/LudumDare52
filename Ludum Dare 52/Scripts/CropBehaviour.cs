using Godot;

public class CropBehaviour : Sprite
{
    #region Data

    private Crop _crop;

    #endregion

    #region Initialisation

    public override void _Ready()
    {
        _crop = new Crop();
        _crop.StateChanged += SetTexture;
    }

    #endregion

    #region Methods

    private void SetTexture()
    {
        switch (_crop.State)
        {
            case CropState.Empty:
                Texture = null;
                break;

            case CropState.Growing:
                if ((_crop.Def.CanRegrow && _crop.Age > _crop.Def.GrowthDays - _crop.Def.RegrowthDays)
                    || (!_crop.Def.CanRegrow && _crop.Age >= _crop.Def.GrowthDays / 2))
                {
                    Texture = _crop.Def.Stage2Sprite;
                }
                else
                {
                    Texture = _crop.Def.Stage1Sprite;
                }
                break;

            case CropState.Ready:
                Texture = _crop.Def.Stage3Sprite;
                break;

            case CropState.Regrowing:
                Texture = _crop.Def.Stage2Sprite;
                break;

            case CropState.Dead:
                Texture = _crop.Def.DeadSprite;
                break;
        }
    }

    #endregion
}
