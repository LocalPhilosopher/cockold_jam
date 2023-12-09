using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Code.Level
{
    public sealed class LevelController : MonoBehaviour
    {
        public static LevelController Instance;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void LevelEnd()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}