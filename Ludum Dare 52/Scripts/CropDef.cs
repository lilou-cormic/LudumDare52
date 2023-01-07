using Godot;

public class CropDef : Resource
{
    [Export] public CropType CropType;

    [Export] public int SeedCost;

    [Export] public int SellPrice;

    [Export] public int GrowthDays;

    [Export] public int RegrowthDays;

    [Export] public Season Season;

    [Export] public Texture Stage1Sprite;

    [Export] public Texture Stage2Sprite;

    [Export] public Texture Stage3Sprite;

    [Export] public Texture DeadSprite;

    [Export] public Texture Icon;

    public bool CanRegrow => RegrowthDays > 0;
}