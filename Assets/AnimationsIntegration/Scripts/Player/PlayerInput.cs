using System;

using UnityEngine;

namespace AnimationsIntegration.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action MovementKeysPressed;
        public event Action MouseMoved;

        private Vector3 lastMousePos;

        private void Update()
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            if (hor != 0 || ver != 0)
            {
                MovementKeysPressed?.Invoke();
            }

            if (Input.mousePosition != lastMousePos)
            {
                MouseMoved?.Invoke();
            }

            lastMousePos = Input.mousePosition;
        }
    }
}
