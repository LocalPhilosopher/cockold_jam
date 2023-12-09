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
        [SerializeField] private Animator animator; 
        
        public void FadeOut()
        {
            fadeImage.color = new Color(0, 0, 0, 1);
            fadeImage.DOColor(new Color(0, 0, 0, 0), .2f);
        }

        public void FadeIn(Action callback)
        {
            animator.SetTrigger("Show");
            fadeImage.DOColor(new Color(0, 0, 0, 1), 1).OnComplete(() =>
            {
                callback?.Invoke();
            });
        }
    }
}