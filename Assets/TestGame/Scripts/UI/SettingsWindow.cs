using TestGame.Controllers;
using TestGame.UI.Bases;
using UnityEngine;
using UnityEngine.UI;

namespace TestGame.UI
{
    public class SettingsWindow : BaseWindow
    {
        [SerializeField] private Toggle musicToggle;

        private void OnEnable()
        {
            InitializeValues();

            musicToggle.onValueChanged.AddListener(OnToggleMusicClicked);
        }

        public void OnCloseButtonClick()
        {
            Root.UIManager.CloseWindow<SettingsWindow>();
        }

        public void OnToggleMusicClicked(bool value)
        {
            Root.PlayerProgress.ActiveSound = value;
            Root.PlayerProgress.Save();
        }

        private void InitializeValues()
        {
            musicToggle.isOn = Root.PlayerProgress.ActiveSound;
        }
    }
}