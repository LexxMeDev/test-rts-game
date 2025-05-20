using UnityEngine;

namespace TestGame.Controllers.Bases
{
    public class Singleton<TModel> : MonoBehaviour
    {
        public static TModel Instance;

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = GetComponent<TModel>();
            DontDestroyOnLoad(gameObject);
        }
    }
}