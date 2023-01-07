using Godot;

namespace PurpleCable
{
    public abstract class PrefabFactory<TNode2D> : Node2D
        where TNode2D : Node2D
    {
        [Export] PackedScene Prefab = null;

        protected virtual TNode2D CreateItem()
        {
            return this.Instantiate<TNode2D>(Prefab);
        }

        protected virtual TNode2D CreateItem(Vector2 globalPosition, float globalRotation = 0f)
        {
            return this.Instantiate<TNode2D>(Prefab, globalPosition, globalRotation);
        }
    }
}
