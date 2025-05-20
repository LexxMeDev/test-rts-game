using TestGame.UI.Bases;

namespace TestGame.Managers.Interfaces
{
    public interface IUIManager : IManager
    {
        T ShowWindow<T>() where T : BaseWindow;
        T ShowWindow<T>(BaseWindow windowPrefab) where T : BaseWindow;
        
        void CloseWindow<T>() where T: BaseWindow;
        void CloseWindow(string windowName);
    }
}