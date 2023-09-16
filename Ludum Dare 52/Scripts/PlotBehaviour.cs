using Godot;
using System.Runtime.CompilerServices;

public class PlotBehaviour : StaticBody2D
{
    #region Data

    private SoilBehaviour _soilBehaviour;

    private CropBehaviour _cropBehaviour;

    #endregion

    #region Initialization

    public override void _Ready()
    {
        _soilBehaviour = GetChild<SoilBehaviour>(1);
        _soilBehaviour.StateChanged += SoilBehaviour_StateChanged;

        _cropBehaviour = GetChild<CropBehaviour>(2);

        SoilBehaviour_StateChanged();
    }

    private void SoilBehaviour_StateChanged()
    {
        _cropBehaviour.SetActive(_soilBehaviour.IsPlantable);
    }

    #endregion

    #region Events

    public void OnInputEvent(Node viewport, InputEvent @event, int shape_idx)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.IsPressed())
        {
            switch (GameManager.CurrentToolType)
            {
                case ToolType.WateringCan:
                    _soilBehaviour.Water();
                    _cropBehaviour.Water();
                    break;

                case ToolType.Hoe:
                    _soilBehaviour.Plow();
                    _cropBehaviour.PlantOrHarvest();
                    break;

                case ToolType.Shovel:
                    _soilBehaviour.Shovel();
                    _cropBehaviour.PlantOrHarvest();
                    break;

                default:
                    if (_soilBehaviour.IsPlantable)
                        _cropBehaviour.PlantOrHarvest();
                    break;
            }
        }
    }

    public void OnMouseEntered()
    {
        _soilBehaviour.SetHighlight(true);

        if (GameManager.CurrentToolType == ToolType.WateringCan &&
            (Input.IsMouseButtonPressed((int)ButtonList.Left) || Input.IsMouseButtonPressed((int)ButtonList.Middle) || Input.IsMouseButtonPressed((int)ButtonList.Right)))
        {
            _soilBehaviour.Water();
            _cropBehaviour.Water();
        }
    }

    public void OnMouseExited()
    {
        _soilBehaviour.SetHighlight(false);
    }

    #endregion
}
