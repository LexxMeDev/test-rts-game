using System.Collections.Generic;
using TestGame.Controllers;
using TestGame.Managers.Bases;
using TestGame.Managers.Interfaces;
using TestGame.UI.Bases;
using UnityEngine;

namespace TestGame.Managers.UI
{
    public class UIManager : BaseManager, IUIManager
    {
        [SerializeField] private List<BaseWindow> showedWindows;
        
        private GameObject _uiCanvas;
        private GameObject UICanvas => _uiCanvas != null 
            ? _uiCanvas = GameObject.FindWithTag(DataStructures.Settings.Constants.UI.GUICanvasTag) 
            : _uiCanvas;

        public T ShowWindow<T>() where T : BaseWindow
        {
            var windowPrefab = Root.GameConfig.WindowsConfig.GetWindowPrefab<T>();
            return ShowWindow<T>(windowPrefab);
        }

        public T ShowWindow<T>(BaseWindow windowPrefab) where T : BaseWindow
        {
            if (UICanvas == null) _uiCanvas = GameObject.FindWithTag(DataStructures.Settings.Constants.UI.GUICanvasTag);

            return CreateWindow<T>(windowPrefab, UICanvas.transform);
        }

        public void CloseWindow<T>() where T : BaseWindow
        {
            CloseWindow(typeof(T).Name);
        }
        
        public void CloseWindow(string windowName)
        {
            var index = showedWindows.FindIndex(item => item.name == windowName);
            if (index == -1) return;

            showedWindows[index].Close();
            showedWindows.RemoveAt(index);
        }
        
        private T CreateWindow<T>(BaseWindow windowPrefab, Transform parent) where T : BaseWindow
        {
            var existingWindow = showedWindows.Find(w => w.name == windowPrefab.name) as T;
            if (existingWindow != null)
                return existingWindow;

            var instance = Instantiate(windowPrefab, parent).GetComponent<T>();
            instance.name = windowPrefab.name;
            showedWindows.Add(instance);

            return instance;
        }
    }
}