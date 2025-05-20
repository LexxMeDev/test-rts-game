namespace TestGame.Interfaces
{
    public interface ICollectable
    {
        bool CanCollect { get; }
        int CollectResources();
    }
}