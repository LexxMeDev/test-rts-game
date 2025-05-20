using System;
using TestGame.DataStructures.Progresses;

namespace TestGame.Managers.Interfaces
{
    public interface IPlayerProgressManager : IManager
    {
        PlayerProgress PlayerProgress { get; }
        
        void LoadPlayerProgress(Action end);
        void SavePlayerProgress();
    }
}