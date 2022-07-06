using System;
using UnityEngine;

namespace AnimationsIntegration.Scripts.Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;

        private void LateUpdate()
        {
            transform.position += playerMovement.GetPositionDifference();
        }
    }
}
