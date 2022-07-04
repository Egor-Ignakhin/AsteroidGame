using System;
using UnityEngine;

namespace Assets.Scripts.Bullets.Movement
{
    internal interface IBulletMovement
    {
        event Action MovementIsOver;

        void Initialize(Vector3 direction, float speed);

        void Move();
    }
}