using TarodevController;
using UnityEngine;

namespace _Code.Obstacles
{
    public class KillerObject : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerController player))
            {
                player.Die();
            }
        }
    }
}