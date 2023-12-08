using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Code.Utils
{
    public class SpringExample : MonoBehaviour
    {
        private float pos;
        private float vel;
        [SerializeField] private float freq = 1;
        [SerializeField] private float dampingRatio = 1;
        public  float displacement;
        [ReadOnly] [SerializeField] SpringUtils.tDampedSpringMotionParams p;

        private void FixedUpdate()
        {
            SpringUtils.CalcDampedSpringMotionParams(ref p, Time.deltaTime,
                freq,dampingRatio);
            SpringUtils.UpdateDampedSpringMotion(ref pos,ref vel, displacement, p);
            // transform.position += Vector3.right * displacement;
            transform.position = Vector3.right * pos;
            // velocity = Mathf.Lerp(velocity, 0, Time.deltaTime);
            // transform.position += Vector3.right * _dir * speed * Time.deltaTime;
        }
    }
}