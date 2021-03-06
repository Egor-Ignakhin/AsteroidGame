using System;
using Asteroids__Atari_.Scripts.Player.Ship.ShipInput;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Player.Ship
{
    public class PausedShipInput : IShipInput
    {
        public event Action MovingKeysPressed;
        public event Action RotationKeysPressed;
        public event Action ShootKeyDown;
        public event Action MouseMoved;

        public float GetMoveSign()
        {
            return 0;
        }

        public void Update()
        {

        }

        public Vector3 GetRotationDirection()
        {
            return Vector3.zero;
        }

        public float GetRotationSign()
        {
            return 0;
        }
    }
}
