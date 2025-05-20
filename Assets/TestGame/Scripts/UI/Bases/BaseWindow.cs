using UnityEngine;

namespace TestGame.UI.Bases
{
    public class BaseWindow : MonoBehaviour
    {
        public void Close()
        {
            Destroy(gameObject);
        }
    }
}