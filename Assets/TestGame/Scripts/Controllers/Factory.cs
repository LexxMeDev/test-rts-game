using System.Collections.Generic;
using System.Linq;
using TestGame.Controllers.Bases;
using TestGame.Managers.Interfaces;
using UnityEngine;

namespace TestGame.Controllers
{
    public class Factory : Singleton<Factory>
    {
        [SerializeField] private List<GameObject> managersPrefabs;

        private readonly Dictionary<System.Type, IManager> _cachedManagers = new();

        public T GetManager<T>() where T : class, IManager
        {
            var type = typeof(T);

            if (_cachedManagers.TryGetValue(type, out var existingManager))
                return existingManager as T;

            var prefab = GetManagerPrefab<T>();
            if (prefab == null)
            {
                Debug.LogError($"[Factory] Manager prefab for type {type.Name} not found.");
                return null;
            }

            var instance = Instantiate(prefab, transform);
            instance.name = prefab.name;

            var managerComponent = instance.GetComponent<T>();
            if (managerComponent == null)
            {
                Debug.LogError($"[Factory] Component {type.Name} not found on prefab {prefab.name}.");
                Destroy(instance);
                return null;
            }

            _cachedManagers[type] = managerComponent;
            return managerComponent;
        }

        private GameObject GetManagerPrefab<T>() where T : IManager
        {
            return managersPrefabs?
                .Where(prefab => prefab != null && prefab.GetComponent<T>() != null)
                .FirstOrDefault();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (managersPrefabs == null)
                return;

            for (int i = 0; i < managersPrefabs.Count; i++)
            {
                var go = managersPrefabs[i];
                if (go != null && go.GetComponent<IManager>() == null)
                {
                    Debug.LogWarning($"[Factory] Removed invalid prefab '{go.name}' at index {i} - missing IManager component.");
                    managersPrefabs[i] = null;
                }
            }
        }
#endif
        
    }
}
