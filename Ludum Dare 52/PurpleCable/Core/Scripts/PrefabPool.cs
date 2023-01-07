using Godot;

namespace PurpleCable
{
    public abstract class PrefabPool<TPoolable> : Pool<TPoolable>
        where TPoolable : Node2D, IPoolable
    {
        [Export] PackedScene Prefab = null;

        protected override TPoolable CreateItem()
        {
            var item = this.Instantiate<TPoolable>(Prefab);
            item.SetAsAvailable();

            return item;
        }
    }
}
