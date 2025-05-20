using System.Collections;
using TestGame.Controllers;
using TestGame.DataStructures.Configs.Buildings;
using TestGame.UI.Bases;
using TMPro;
using UnityEngine;

namespace TestGame.UI
{
    public class ResourcePopup : BaseWindow
    {
        [SerializeField] private TextMeshProUGUI textMeshPro;

        public void Initialize(ResourceData data, int amount)
        {
            textMeshPro.text = $"{data.Name} x{amount}";
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(Root.GameConfig.PopupTime);

            Root.UIManager.CloseWindow<ResourcePopup>();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}