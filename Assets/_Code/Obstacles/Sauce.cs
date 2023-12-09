using TarodevController;
using UnityEngine;

namespace _Code.Obstacles
{
    public sealed class Sauce : MonoBehaviour
    {
        [SerializeField] private float _speedCoefficient;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerController player))
            {
                player.SetSetSpeedModifier(_speedCoefficient);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerController player))
            {
                player.SetSetSpeedModifier(1f);
            }
        }
    }
}