using System;
using UnityEngine;

namespace Assets.Scripts.Player.Ship
{
    public interface IShipInput
    {
        event Action MovingKeysPressed;
        event Action RotationKeysPressed;
        event Action ShootKeyDown;
        event Action MouseMoved;

        float GetMoveSign();

        float GetRotationSign();
        
        void Update();
    }
}