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
        [SerializeField] private AudioSource source;
        [SerializeField] private Transform basket;
        [SerializeField] private AudioClip metalGearSfx;
        [SerializeField] private AudioClip brokenHeartSfx;
        [SerializeField] private AudioClip loseSfx;
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
                _entered = true;
                basket.gameObject.SetActive(true);
                basket.position = player.transform.position + Vector3.up * 100;
                basket.parent = player.transform;
                Time.timeScale = .1f;
                // source.PlayOneShot(metalGearSfx);
                // UIEye.Instance.ShowAnim();
                // Time.fixed = .1f;
                
                var seq = DOTween.Sequence();
                source.PlayOneShot(loseSfx);
                seq.AppendInterval(.15f).OnComplete(() =>
                {
                    heart.gameObject.SetActive(false);
                    brokenHeart.gameObject.SetActive(true);
                    source.PlayOneShot(brokenHeartSfx);
                    Time.timeScale = 1;
                    seq.Append(basket.DOLocalMove(Vector3.zero, .4f).OnComplete(() =>
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