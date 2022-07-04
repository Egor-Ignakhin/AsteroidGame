using System;
using UnityEngine;

namespace Assets.Scripts
{
    internal interface IBulletMotion
    {
        event Action MovementIsOver;

        void Initialize(Vector3 direction, float speed);

        void Move();
    }
}