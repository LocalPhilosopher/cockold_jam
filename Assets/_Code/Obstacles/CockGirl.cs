using System;
using _Code.Level;
using DG.Tweening;
using TarodevController;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.Obstacles
{
    public class CockGirl : MonoBehaviour
    {
        [SerializeField] private Transform basket;
        [SerializeField] private AudioClip brokenHeartSfx;
        [SerializeField] private Transform heart;
        [SerializeField] private Transform brokenHeart ;

        private bool _entered;
        private void Awake()
        {
            basket.gameObject.SetActive(false);
        }


        private void OnTriggerEnter2D(Collider2D col)
        {
            
            if (col.TryGetComponent<PlayerController>(out var player))
            {
                if (_entered)
                    return;
                heart.gameObject.SetActive(false);
                brokenHeart.gameObject.SetActive(true);
                _entered = true;
                basket.gameObject.SetActive(true);
                basket.position = player.transform.position + Vector3.up * 100;
                basket.parent = player.transform;
                Time.timeScale = .1f;
                // Time.fixed = .1f;
                var seq = DOTween.Sequence();
                seq.AppendInterval(.3f).OnComplete(() =>
                {
                    Time.timeScale = 1;
                    seq.Append(basket.DOLocalMove(Vector3.zero, .2f).OnComplete(() =>
                    {
                        LevelController.Instance.Player.DeactivateRb();
                        player.Animator.HideVisual();
                        LevelController.Instance.LevelEnd();
                    }));
                    
                });
                

            }
        }
    }
}