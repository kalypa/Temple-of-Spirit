using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemInven
{
    public class GenericDoorOpen : MonoBehaviour
    {
        [HideInInspector] public Animator doorAnim;

        public string animationName = null;

        private void Start()
        {
            doorAnim = GetComponent<Animator>();
        }

        public void PlayAnimation()
        {
            doorAnim.speed = 1;
            doorAnim.Play(animationName, 0, 0.0f);         
        }
    }
}
