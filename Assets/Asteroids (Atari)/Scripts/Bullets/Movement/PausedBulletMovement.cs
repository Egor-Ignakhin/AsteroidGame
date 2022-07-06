using System;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Bullets.Movement
{
    public class PausedBulletMovement : IBulletMovement
    {
        public event Action MovementIsOver;

        public void Initialize(Vector3 direction, float speed)
        {
        }

        public void Move()
        {
        }
    }
}