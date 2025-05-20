using TestGame.Controllers;
using TestGame.UI.Bases;

namespace TestGame.UI
{
    public class PlayingWindow : BaseWindow
    {
        public void OnSettingsButtonClick() => Root.UIManager.ShowWindow<SettingsWindow>();
    }
}