using System;
using Assets.Scripts.Player.Ship.ShipInput;
using UnityEngine;

namespace Assets.Scripts.Player.Ship
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
