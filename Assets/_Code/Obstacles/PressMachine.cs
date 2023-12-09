using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace _Code.Obstacles
{
    public sealed class PressMachine : MonoBehaviour
    {
        [SerializeField] private KillerObject _deathCollider;
        
        [SerializeField] private float _smashDistance;
        [SerializeField] private float _safeTime;
        [SerializeField] private float _smashTime;
        [SerializeField] private float _smashedDuration;
        [SerializeField] private float _backDuration;

        private void Awake()
        {
            StartCoroutine(Smash());
        }

        private IEnumerator Smash()
        {
            var safeTimeAwait = new WaitForSeconds(_safeTime);
            var smashTimeAwait = new WaitForSeconds(_smashTime);
            var smashedTimeAwait = new WaitForSeconds(_smashedDuration);
            var backTimeAwait = new WaitForSeconds(_backDuration);
            
            while (true)
            {
                yield return safeTimeAwait;
                _deathCollider.IsActive = true;
                transform.DOMoveY(transform.position.y - _smashDistance, _smashTime).SetEase(Ease.InQuad);
                yield return smashTimeAwait;
                yield return smashedTimeAwait;
                _deathCollider.IsActive = false;
                transform.DOMoveY(transform.position.y + _smashDistance, _backDuration);
                yield return backTimeAwait;
            }
        }

        private void OnDrawGizmosSelected()
        {
            var y = -_smashDistance - 0.5f;
            Gizmos.DrawLine(
                    transform.position + new Vector3(-1, y),
                    transform.position + new Vector3(+1, y));
        }
    }
}