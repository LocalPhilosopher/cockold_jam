using System;
using TarodevController;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Code.Level
{
    public sealed class LevelController : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private AudioSource source;
        [SerializeField] private AudioClip deathSFX;
        public static LevelController Instance;

        public PlayerController Player => player;
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

        public void LevelFailed()
        {
            source.PlayOneShot(deathSFX);
            UISceneManager.Instance.FadeInWithoutAnim(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });
        }
    }
}