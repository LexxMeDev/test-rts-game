using TestGame.DataStructures.Configs.Buildings;
using UnityEngine;

namespace TestGame.Controllers.Buildings
{
    public class FactorySpawner : MonoBehaviour
    {
        [SerializeField] private FactoryData[] factoryDatas;
        [SerializeField] private Transform[] spawnPoints;

        private void Start()
        {
            factoryDatas = Root.GameConfig.FactoryData.ToArray();

            if (factoryDatas.Length != spawnPoints.Length)
            {
                return;
            }

            for (int i = 0; i < factoryDatas.Length; i++)
            {
                SpawnFactory(factoryDatas[i], spawnPoints[i]);
            }
        }

        private void SpawnFactory(FactoryData data, Transform spawnPoint)
        {
            var factoryObj = Instantiate(data.ModelPrefab, spawnPoint.position, spawnPoint.rotation);
            var factory = factoryObj.GetComponent<TestGame.Controllers.Buildings.Factory>();
            factory.Initialize(data);
            factory.StartProduction();
        }
    }
}