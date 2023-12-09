using System;
using TarodevController;
using UnityEngine;

namespace _Code.Obstacles
{
    public sealed class FallingPlatformStandZone : MonoBehaviour
    {
        public event Action Triggered;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerController player))
            {
                Triggered?.Invoke();
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}