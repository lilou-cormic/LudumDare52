namespace PurpleCable
{
    public interface IPoolable
    {
        bool IsInUse { get; }

        void SetAsInUse();

        void SetAsAvailable();
    }
}
