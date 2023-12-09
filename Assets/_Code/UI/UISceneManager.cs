using System;
using _Code.Utils;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Code
{
    public class UISceneManager : SingletonMono<UISceneManager>
    {
        [SerializeField] private Image fadeImage;
        
        private void Start()
        {
            FadeOut();
        }

        public void FadeOut()
        {
        }

        public void FadeIn(Action callback)
        {
            callback?.Invoke();
        }
    }
}