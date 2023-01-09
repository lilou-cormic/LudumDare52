using Godot;
using PurpleCable;

public class CoinFactory : PrefabFactory<CoinBehaviour>
{
    private static CoinFactory _instance;

    public CoinFactory()
    {
        _instance = this;
    }

    public static void Spawn(Vector2 globalPosition)
    {
        _instance.CreateItem(globalPosition);
    }
}