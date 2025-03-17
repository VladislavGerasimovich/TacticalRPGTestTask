using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bootstrap
{
    public class PerformBootstrap : MonoBehaviour
    {
        private const string SceneName = "BootstrappedScene";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Execute()
        {
            for (int sceneIndex = 0; sceneIndex < SceneManager.sceneCount; ++sceneIndex)
            {
                var candidate = SceneManager.GetSceneAt(sceneIndex);

                if(candidate.name == SceneName)
                {
                    return;
                }
            }

            SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        }
    }
}