using TestGame.DataStructures.Settings;
using UnityEngine;

namespace TestGame.DataStructures.Configs.Buildings
{
    [CreateAssetMenu(menuName = Constants.MainMenuGame + "Factory System/" + nameof(FactoryData))]
    public class FactoryData : ScriptableObject
    {
        [SerializeField] private string factoryName;
        [SerializeField] private int storageCapacity = 10;
        [SerializeField] private float productionTime = 5f;

        [SerializeField] private Color modelColor;
        [SerializeField] private GameObject modelPrefab;
        [SerializeField] private ResourceData productionResource;

        public string FactoryName => factoryName;

        public int StorageCapacity => storageCapacity;

        public float ProductionTime => productionTime;

        public Color ModelColor => modelColor;

        public GameObject ModelPrefab => modelPrefab;

        public ResourceData ProductionResource => productionResource;
    }
}