using System;
using Asteroids__Atari_.Scripts.Player.Ship.Cannon;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Player.Ship.ShipInput
{
    public class KeyboardShipInput : IShipInput
    {
        private float timeFromLastShot;
        public event Action MovingKeysPressed;
        public event Action RotationKeysPressed;
        public event Action ShootKeyDown;
        public event Action MouseMoved;

        public float GetMoveSign()
        {
            return Math.Sign(CalcVerAxis());
        }

        public virtual float GetRotationSign()
        {
            return Math.Sign(CalcHorAxis());
        }

        public virtual void Update()
        {
            float verAxis = CalcVerAxis();
            float horAxis = CalcHorAxis();

            if (verAxis != 0)
            {
                MovingKeysPressed?.Invoke();
            }
            if (horAxis != 0)
            {
                RotationKeysPressed?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (timeFromLastShot > 1f / ShipsCannon.GetMaxShootsPerSecond())
                {
                    ShootKeyDown?.Invoke();
                    timeFromLastShot = 0;
                }
            }

            timeFromLastShot += Time.deltaTime;
        }

        protected virtual float CalcVerAxis()
        {
            var verAxis = Input.GetAxis("Vertical");

            return verAxis;
        }

        protected virtual float CalcHorAxis()
        {
            return -Input.GetAxis("Horizontal");
        }

        protected void CallMouseMoved()
        {
            MouseMoved?.Invoke();
        }
    }
}