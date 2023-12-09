using System;
using _Code.Level;
using TarodevController;
using UnityEngine;

namespace _Code.Obstacles
{
    public class CockGirl : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            
            if (col.GetComponent<PlayerController>())
            {
                LevelController.Instance.LevelEnd();
            }
        }
    }
}