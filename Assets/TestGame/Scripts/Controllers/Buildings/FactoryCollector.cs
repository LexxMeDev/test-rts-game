using TestGame.Controllers.Player;
using UnityEngine;

namespace TestGame.Controllers.Buildings
{
    public class FactoryCollector : MonoBehaviour
    {
        public static FactoryCollector Instance { get; private set; }

        [SerializeField] private Transform player;
        [SerializeField] private CharacterMovement movement;
        [SerializeField] private float collectionDistance;
        
        private Factory _targetFactory;

        private void Awake()
        {
            Instance = this;
        }

        public void HandleFactoryClick(Factory factory)
        {
            if (IsPlayerInFactoryTrigger(factory))
            {
                factory.CollectResources();
                return;
            }

            _targetFactory = factory;
            movement.MoveTo(factory.transform.position);
        }

        private bool IsPlayerInFactoryTrigger(Factory factory)
        {
            float distance = Vector3.Distance(player.position, factory.transform.position);
            return distance <= collectionDistance;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_targetFactory == null) return;

            if (other.CompareTag("Player") && other.transform == player)
            {
                float dist = Vector3.Distance(player.position, _targetFactory.transform.position);

                if (dist <= collectionDistance)
                {
                    _targetFactory.CollectResources();
                    _targetFactory = null;
                }
            }
        }
    }
}
