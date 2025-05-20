using System.Collections.Generic;
using TestGame.DataStructures.Configs.Bases;
using TestGame.DataStructures.Settings;
using TestGame.UI.Bases;
using UnityEngine;

namespace TestGame.DataStructures.Configs
{
    [CreateAssetMenu(menuName = Constants.MainMenuGame + nameof(WindowsConfig))]
    public class WindowsConfig : BaseConfig
    {
        [SerializeField] private List<BaseWindow> windows;
        
        public T GetWindowPrefab<T>() where T : BaseWindow
        {
            Debug.Log($"[UI] Finding window by  name: {typeof(T).Name}");
            var config = windows.Find(item => item.name == typeof(T).Name);
            return config == null ? null : config.GetComponent<T>();
        }
    }
}