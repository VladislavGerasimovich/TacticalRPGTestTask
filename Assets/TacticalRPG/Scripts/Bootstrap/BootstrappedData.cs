using GridLayout.DataStorage;
using UnityEngine;

namespace Bootstrap
{
    [RequireComponent(typeof(JSONController))]
    public class BootstrappedData : MonoBehaviour
    {
        private JSONController _jsonController;

        public static BootstrappedData Instance { get; private set; } = null;
        public JSONController JSONController => _jsonController;

        private void Awake()
        {
            _jsonController = GetComponent<JSONController>();
            _jsonController.Init();

            if (Instance != null)
            {
                Destroy(gameObject);

                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}