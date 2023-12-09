using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Code.Obstacles
{
    public sealed class FallingPlatform : MonoBehaviour
    {
        [SerializeField] private float _stabilityDuration;
        [SerializeField] private float _animationDuration;

        private Collider2D _collider2d;

        private void Awake()
        {
            _collider2d = GetComponent<Collider2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            PrepareToFall().Forget();
        }

        private async UniTaskVoid PrepareToFall()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_stabilityDuration));

            var sequence = DOTween.Sequence();
            sequence.Append(transform.DORotate(new Vector3(0, 0, 5), _animationDuration / 3f));
            sequence.Append(transform.DORotate(new Vector3(0, 0, -5), _animationDuration / 3f));
            sequence.Append(transform.DORotate(new Vector3(0, 0, 0), _animationDuration / 3f));
            sequence.Play();
            await sequence.ToUniTask();

            _collider2d.enabled = false;
            transform.DOMoveY(transform.position.y - 100, 1f);
        }
    }
}