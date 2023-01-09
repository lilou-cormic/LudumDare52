using Godot;
using PurpleCable;
using System.Collections.Generic;

public class CropBehaviour : Sprite
{
    #region Editor

    [Export] AudioStream PlantSound;

    [Export] AudioStream HarvestSound;

    [Export] AudioStream ActionDeniedSound;

    #endregion

    #region Data

    private Crop _crop;

    private List<SimpleAnimation> _animations;

    private AudioStreamPlayer _soundPlayer;

    #endregion

    #region Initialisation

    public override void _Ready()
    {
        _soundPlayer = GetChild<AudioStreamPlayer>(0);
        _soundPlayer.VolumeDb = GameManager.SfxVolume;

        _crop = new Crop();
        _crop.StateChanged += SetTexture;

        _animations = new List<SimpleAnimation>()
        {
            new ScaleAnimation(this) { Duration = 0.3f, EndLocalScale = new Vector2(Scale.x * 0.9f, Scale.y * 1.2f) },
            new ScaleAnimation(this) { Delay = 0.3f, Duration = 1, EndLocalScale = Scale },
        };
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

    public void PlantOrHarvest()
    {
        if (_crop.State != CropState.Empty)
        {
            if (_crop.CanHarvest)
            {
                if (_crop.State == CropState.Ready)
                    CoinFactory.Spawn(GlobalPosition);

                _soundPlayer.Stream = HarvestSound;
                _soundPlayer.Play();

                _crop.Harvest();

                return;
            }
        }
        else
        {
            CropDef cropDef = Crops.GetCropDef(GameManager.CurrentCropType);

            if (cropDef.Season.HasFlag(GameManager.Season) && cropDef.SeedCost <= GameManager.Money)
            {
                _soundPlayer.Stream = PlantSound;
                _soundPlayer.Play();

                _crop.Plant(Crops.GetCropDef(GameManager.CurrentCropType));

                _animations.ForEach(animation => animation.Start());

                return;
            }
        }

        _soundPlayer.Stream = ActionDeniedSound;
        _soundPlayer.Play();
    }

    public override void _PhysicsProcess(float delta)
    {
        _animations.ForEach(animation => animation.PhysicsProcess(delta));
    }

    #endregion
}
