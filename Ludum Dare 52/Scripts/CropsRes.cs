using Godot;

public class CropsRes : Node2D
{
    #region Initialization

    public override void _Ready()
    {
        Crops.SetDefs(new Crops.CropTypeResourceDictionary(GetNode<ResourceNode2D>("CropsRes").LoadAll<CropDef>()));
    }

    #endregion
}