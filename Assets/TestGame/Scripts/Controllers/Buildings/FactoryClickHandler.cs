using UnityEngine;
using UnityEngine.EventSystems;

namespace TestGame.Controllers.Buildings
{
    public class FactoryClickHandler : MonoBehaviour
    {
        private Factory _factory;

        private void Awake()
        {
            _factory = GetComponent<Factory>();
        }

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            FactoryCollector.Instance.HandleFactoryClick(_factory);
        }
    }
}