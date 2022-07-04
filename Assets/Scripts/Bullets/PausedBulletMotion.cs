using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PausedBulletMotion : IBulletMotion
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