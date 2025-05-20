using System.Collections;
using TestGame.DataStructures.Configs.Buildings;
using TestGame.DataStructures.Models.Buildings;
using TestGame.Interfaces;
using TestGame.UI;
using UnityEngine;
using UnityEngine.AI;

namespace TestGame.Controllers.Buildings
{
    [RequireComponent(typeof(NavMeshObstacle))]
    public class Factory : MonoBehaviour, IProducible, ICollectable
    {
        [SerializeField] private FactoryData data;
        [SerializeField] private LayerMask buildingLayer;
        [SerializeField] private FactoryUI ui;

        private ResourceStorage _storage;
        private bool _isProducing;

        public int ResourceID => data.ProductionResource.Id;
        public float ProductionTime => data.ProductionTime;
        public bool CanCollect => _storage.CurrentAmount > 0;

        private void InitializeUI()
        {
            ui.Initialize(data);
        }

        public void Initialize(FactoryData data)
        {
            if (data == null)
            {
                return;
            }

            this.data = data;

            var renderer = GetComponent<Renderer>();

            if (renderer != null)
            {
                renderer.material.color = this.data.ModelColor;
            }

            var obstacle = GetComponent<NavMeshObstacle>();

            if (obstacle != null)
            {
                obstacle.shape = NavMeshObstacleShape.Box;
                obstacle.carving = true; 
            }

            _storage = new ResourceStorage(this.data.StorageCapacity);

            InitializeUI();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                CollectResources();
            }
        }

        public void StartProduction()
        {
            if (_isProducing) return;
            _isProducing = true;

            StartCoroutine(ProductionRoutine());
        }

        private IEnumerator ProductionRoutine()
        {
            while (_isProducing && !_storage.IsFull)
            {
                yield return new WaitForSeconds(data.ProductionTime);
                _storage.AddResource(1);
                ui.UpdateAmount(_storage.CurrentAmount);
            }

            _isProducing = false;
        }

        public void StopProduction() => _isProducing = false;

        public int CollectResources()
        {
            if (_storage.CurrentAmount == 0) return 0;

            Root.UIManager.CloseWindow<ResourcePopup>();
            var window = Root.UIManager.ShowWindow<ResourcePopup>();
            window.Initialize(data.ProductionResource, _storage.CurrentAmount);

            int amount = _storage.CurrentAmount;
            _storage.EmptyStorage();
            ui.UpdateAmount(0);
            return amount;
        }
    }
}