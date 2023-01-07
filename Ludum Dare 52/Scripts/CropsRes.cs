using Godot;
using static Crops;

public class CropsRes : Node2D
{
    #region Initialization

    public override void _Ready()
    {
        Crops.SetDefs(new CropTypeResourceDictionary(GetNode<ResourceNode2D>("CropsRes").LoadAll<CropDef>()));
    }

    #endregion
}