using TestGame.DataStructures.Configs.Buildings;
using TMPro;
using UnityEngine;

namespace TestGame.Controllers.Buildings
{
    public class FactoryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI amountText;
        [SerializeField] Canvas canvas;

        private Camera _camera;
        private FactoryData _factoryData;

        public void Initialize(FactoryData factoryData)
        {
            _factoryData = factoryData;
            _camera = Camera.main;
            canvas.worldCamera = _camera;
            UpdateAmount(0);
        }

        void LateUpdate()
        {
            if (_camera == null) return;

            Vector3 dir = transform.position - _camera.transform.position;
            Quaternion rotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = rotation;
        }

        public void UpdateAmount(int amount)
        {
            if (_factoryData == null || _factoryData.ProductionResource == null)
            {
                amountText.text = $"x{amount}";
                return;
            }

            amountText.text = $"{_factoryData.ProductionResource.Name} x{amount}";
        }

    }
}