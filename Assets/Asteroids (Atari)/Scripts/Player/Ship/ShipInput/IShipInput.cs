using System;

namespace Asteroids__Atari_.Scripts.Player.Ship.ShipInput
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