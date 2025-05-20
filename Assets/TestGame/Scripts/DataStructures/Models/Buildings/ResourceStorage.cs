namespace TestGame.DataStructures.Models.Buildings
{
    public class ResourceStorage
    {
        private readonly int _capacity;
        private int _currentAmount;

        public int CurrentAmount => _currentAmount;
        public bool IsFull => _currentAmount >= _capacity;

        public ResourceStorage(int capacity) => _capacity = capacity;

        public bool AddResource(int amount)
        {
            if (_currentAmount + amount > _capacity) return false;
            _currentAmount += amount;
            return true;
        }

        public void EmptyStorage() => _currentAmount = 0;
    }
}