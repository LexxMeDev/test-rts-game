using TestGame.Controllers.Bases;
using TestGame.DataStructures.Settings;
using TestGame.UI;
using UnityEngine.SceneManagement;

namespace TestGame.Controllers
{
    public class StartGameController : BaseController
    {
        public void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            Root.PlayerProgressManager.LoadPlayerProgress(() =>
            {
                SceneManager.LoadScene(Constants.GameSceneName);
            });
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == Constants.GameSceneName)
                Root.UIManager.ShowWindow<PlayingWindow>();
        }
    }
}