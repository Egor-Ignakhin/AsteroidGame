using System;
using UnityEngine;

namespace Assets.Scripts.Player.Ship
{
    public interface IShipInput
    {
        public event Action AccelerationKeysPressed;
        public event Action RotationKeysPressed;
        public event Action ShootKeyDown;
        float GetMoveSign();

        void Update();
        Vector3 GetRotationDirection();
    }
}