using TestGame.DataStructures.Settings;
using UnityEngine;

namespace TestGame.DataStructures.Configs.Buildings
{
    [CreateAssetMenu(menuName = Constants.MainMenuGame + "Factory System/" + nameof(ResourceData))]
    public class ResourceData : ScriptableObject
    {
        [SerializeField] private int id;
        [SerializeField] private string name;
        [SerializeField] private Sprite icon;

        public int Id => id;

        public string Name => name;

        public Sprite Icon => icon;
    }
}