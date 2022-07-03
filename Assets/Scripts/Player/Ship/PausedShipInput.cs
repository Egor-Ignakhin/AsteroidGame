using Assets.Scripts.Player.Ship;

using System;

using UnityEngine;

public class PausedShipInput : IShipInput
{
    public event Action AccelerationKeysPressed;
    public event Action RotationKeysPressed;
    public event Action ShootKeyDown;

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
}
