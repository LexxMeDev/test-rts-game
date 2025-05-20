using TestGame.DataStructures.Configs;

namespace TestGame.DataStructures.Settings
{
    public static class Constants
    {
        public const string MainMenuGame = nameof(TestGame) + "/";
        public const string GameSceneName = "Game";
        
        public static class UI
        {
            public const string GUICanvasTag = "GUICanvas";
        }

        public static class Resources
        {
            public const string BasePath = nameof(TestGame) + "/" + "Configs/";
            public const string GameConfigPath = BasePath + nameof(GameConfig);
        }

        public static class PlayerPrefsKeys
        {
            public const string PlayerProgressSave = "PlayerProgress";
        }
    }
}