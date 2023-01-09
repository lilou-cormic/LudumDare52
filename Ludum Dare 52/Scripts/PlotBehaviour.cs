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
        _cropBehaviour = GetChild<CropBehaviour>(2);
    }

    #endregion

    #region Events

    public void OnInputEvent(Node viewport, InputEvent @event, int shape_idx)
    {
        if (@event is InputEventMouseButton mouseEvent && mouseEvent.IsPressed())
            _cropBehaviour.PlantOrHarvest();
    }

    public void OnMouseEntered()
    {
        //if (Input.IsMouseButtonPressed((int)ButtonList.Left) || Input.IsMouseButtonPressed((int)ButtonList.Middle) || Input.IsMouseButtonPressed((int)ButtonList.Right))
        //    _cropBehaviour.PlantOrHarvest();

        _soilBehaviour.SetHighlight(true);
    }

    public void OnMouseExited()
    {
        _soilBehaviour.SetHighlight(false);
    }

    #endregion
}
