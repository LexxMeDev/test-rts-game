using System;
using TestGame.Controllers;
using TestGame.DataStructures.Progresses;
using TestGame.DataStructures.Settings;
using TestGame.Managers.Bases;
using TestGame.Managers.Interfaces;
using UnityEngine;

namespace TestGame.Managers.Progresses
{
    public class PlayerProgressManager : BaseManager, IPlayerProgressManager
    {
        private PlayerProgress _playerProgress;
        public PlayerProgress PlayerProgress => _playerProgress;
        
        public void LoadPlayerProgress(Action end)
        {
            var jsonData = PlayerPrefs.GetString(Constants.PlayerPrefsKeys.PlayerProgressSave);

            if (!string.IsNullOrEmpty(jsonData))
            {
                _playerProgress = JsonUtility.FromJson<PlayerProgress>(jsonData);
                end?.Invoke();
                return;
            }

            _playerProgress = new PlayerProgress(Guid.NewGuid().ToString());
            SavePlayerProgress();
            
            end?.Invoke();
        }
        
        public void SavePlayerProgress()
        {
            if (Root.PlayerProgress == null)
            {
                Debug.LogError("[PlayerProgress] PlayerProgress is equal of null.");
                return;
            }
            
            PlayerPrefs.SetString(Constants.PlayerPrefsKeys.PlayerProgressSave, JsonUtility.ToJson(Root.PlayerProgress));
        }
    }
}