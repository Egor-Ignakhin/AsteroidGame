using System;
using UnityEngine;

namespace Assets.Scripts.Player.Ship
{
    public class KeyboardShipInput : IShipInput
    {
        private float timeFromLastShot;
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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (timeFromLastShot > 1f / 3)
                {
                    ShootKeyDown?.Invoke();
                    timeFromLastShot = 0;
                }
            }

            timeFromLastShot += Time.deltaTime;
        }

        private float CalcVerAxis()
        {
            var verAxis = Input.GetAxis("Vertical");

            return verAxis;
        }

        private Vector3 CalcHorDirection()
        {
            return new Vector3(0, 0, -Input.GetAxis("Horizontal"));
        }
    }
}