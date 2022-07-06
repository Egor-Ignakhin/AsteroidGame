using System;
using UnityEngine;

namespace AnimationsIntegration.Scripts.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator anim;

        private void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            anim.SetFloat("Speed", v);
            anim.SetFloat("Direction", h);
        }
    }
}
