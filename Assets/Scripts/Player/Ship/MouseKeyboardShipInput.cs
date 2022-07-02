using System;
using UnityEngine;

namespace Assets.Scripts.Player.Ship
{
    public class MouseKeyboardShipInput : MonoBehaviour, IShipInput
    {
        public event Action AccelerationKeysPressed;
        public event Action RotationKeysPressed;
        public event Action ShootKeyDown;
        public float GetMoveSign()
        {
            return Math.Sign(CalcVerAxis());
        }

        public Vector3 GetRotationDirection()
        {
            return CalcHorDirection();
        }

        private Vector3 lastMousePos;

        public void Update()
        {
            float verAxis = CalcVerAxis();
            float horAxis = CalcHorDirection().magnitude;

            if (verAxis != 0)
            {
                AccelerationKeysPressed?.Invoke();
            }
            if (horAxis != 0)
            {
                RotationKeysPressed?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Space) ||
                Input.GetMouseButtonDown(1))
            {
                ShootKeyDown?.Invoke();
            }
        }

        private float CalcVerAxis()
        {
            var verAxis = Input.GetAxis("Vertical");

            if (verAxis != 0)
            {
                return verAxis;
            }
            if (Input.GetMouseButton(0))
            {
                verAxis = 1;
            }

            return verAxis;
        }

        private Vector3 CalcHorDirection()
        {
            var dir = lastMousePos - Input.mousePosition;

            if (dir.magnitude > 1)
            {
                dir = dir.normalized;
            }

            lastMousePos = Input.mousePosition;
            return dir;
        }
    }
}