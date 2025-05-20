namespace TestGame.Interfaces
{
    public interface IProducible
    {
        int ResourceID { get; }
        float ProductionTime { get; }
        void StartProduction();
        void StopProduction();
    }
}