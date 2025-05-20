using TestGame.Controllers.Bases;
using TestGame.DataStructures.Configs;
using TestGame.DataStructures.Progresses;
using TestGame.DataStructures.Settings;
using TestGame.Managers.Interfaces;
using UnityEngine;

namespace TestGame.Controllers
{
    public class Root : Singleton<Root>
    {
        private static Factory Factory => Factory.Instance;
        
        private static IUIManager _uiManager;
        private static IPlayerProgressManager _playerProgressManager;
        
        private GameConfig _gameConfig;
        public static GameConfig GameConfig => Instance._gameConfig;
        public static PlayerProgress PlayerProgress => _playerProgressManager.PlayerProgress;

        protected override void Awake()
        {
            base.Awake();
            
            _gameConfig = Resources.Load<GameConfig>(Constants.Resources.GameConfigPath);
            DontDestroyOnLoad(gameObject);
        }
        
        public static IUIManager UIManager
        {
            get
            {
                if (_uiManager == null)
                    _uiManager = Factory.GetManager<IUIManager>();
                return _uiManager;
            }
        }

        public static IPlayerProgressManager PlayerProgressManager
        {
            get
            {
                if (_playerProgressManager == null)
                    _playerProgressManager = Factory.GetManager<IPlayerProgressManager>();
                return _playerProgressManager;
            }
        }
    }
}