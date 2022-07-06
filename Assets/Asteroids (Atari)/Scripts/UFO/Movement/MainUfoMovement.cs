using System;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.UFO.Movement
{
    public class MainUfoMovement : IUfoMovement
    {
        public event Action MovementIsOver;
        private readonly Transform mTransform;
        private Vector3 targetPosition;
        private Vector3 startPosition;
        private float time;


        public MainUfoMovement(Transform mTransform)
        {
            this.mTransform = mTransform;
        }

        public void Initialize(Vector3 startPosition, Vector3 targetPosition)
        {
            this.startPosition = startPosition;
            this.targetPosition = targetPosition;

            time = 0;
        }

        public void Move()
        {
            time += Time.fixedDeltaTime / 10f;
            mTransform.position = Vector3.Lerp(startPosition, targetPosition, time);

            TakeStatistics();
        }

        private void TakeStatistics()
        {
            if (mTransform.position == targetPosition)
            {
                MovementIsOver?.Invoke();
            }
        }
    }
}