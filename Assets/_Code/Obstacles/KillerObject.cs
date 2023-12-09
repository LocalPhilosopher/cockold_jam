using TarodevController;
using UnityEngine;

namespace _Code.Obstacles
{
    public class KillerObject : MonoBehaviour
    {
        [field: SerializeField] public bool IsActive { get; set; }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!IsActive)
                return;
            
            if (other.gameObject.TryGetComponent(out PlayerController player))
            {
                player.Die();
            }
        }
    }
}