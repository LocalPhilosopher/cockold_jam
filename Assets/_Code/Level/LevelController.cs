using System;
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

        private void Start()
        {
            LevelStart();
        }

        public void LevelStart()
        {
            UISceneManager.Instance.FadeOut();;
        }

        public void LevelEnd()
        {
            UISceneManager.Instance.FadeIn(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            });
        }
    }
}