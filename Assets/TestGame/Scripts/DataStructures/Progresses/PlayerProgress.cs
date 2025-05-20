using System;
using TestGame.Controllers;
using UnityEngine;

namespace TestGame.DataStructures.Progresses
{
    [Serializable]
    public class PlayerProgress
    {
        [SerializeField] private string id;
        [SerializeField] private bool activeSound;

        public bool ActiveSound
        {
            get => activeSound;
            set => activeSound = value;
        }

        public PlayerProgress() { }
        public PlayerProgress(string id) { this.id = id; }

        public void Save()
        {
            Root.PlayerProgressManager.SavePlayerProgress();
        }
    }
}