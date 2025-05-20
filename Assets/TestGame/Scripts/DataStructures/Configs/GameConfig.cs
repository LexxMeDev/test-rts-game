using System.Collections.Generic;
using TestGame.DataStructures.Configs.Bases;
using TestGame.DataStructures.Configs.Buildings;
using TestGame.DataStructures.Settings;
using UnityEngine;

namespace TestGame.DataStructures.Configs
{
    [CreateAssetMenu(menuName = Constants.MainMenuGame + nameof(GameConfig))]
    public class GameConfig : BaseConfig
    {
        [Space(10)] [Header("UI")]
        [SerializeField] private WindowsConfig windowsConfig;
        [SerializeField] private int popupTime;

        [Space(10)] [Header("Buildings")]
        [SerializeField] private List<FactoryData> factoryData;

        public WindowsConfig WindowsConfig => windowsConfig;
        public int PopupTime => popupTime;
        public List<FactoryData> FactoryData => factoryData;
    }
}