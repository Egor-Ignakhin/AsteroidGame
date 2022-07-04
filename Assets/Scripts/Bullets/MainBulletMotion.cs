using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class MainBulletMotion : IBulletMotion
    {
        public event  Action MovementIsOver;
        private readonly Transform mTransform;
        private Vector3 direction;
        private float speed;
        private float movedDistance;
        private Vector3 lastPosition;

        public MainBulletMotion(Transform transform)
        {
            mTransform = transform;
        }

        public void Initialize(Vector3 direction, float speed)
        {
            this.direction = direction;
            this.speed = speed;
            movedDistance = 0;
        }

        public void Move()
        {
            lastPosition = mTransform.position;
            mTransform.position += direction * speed;

            TakeStatistics();
        }

        private void TakeStatistics()
        {
            movedDistance += Vector3.Distance(lastPosition, mTransform.position);

            if (movedDistance > Screen.width)
            {
                MovementIsOver?.Invoke();
            }
        }
    }
}