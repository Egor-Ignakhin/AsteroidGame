using UnityEngine;

namespace Assets.Scripts.Asteroids.AsteroidMovement
{
    public class MainAsteroidMovement : IAsteroidMovement
    {
        private readonly Transform mTransform;
        private Vector3 direction;
        private float speed;

        public MainAsteroidMovement(Transform mTransform)
        {
            this.mTransform = mTransform;
        }

        public void Initialize(Vector3 direction, float speed)
        {
            this.direction = direction;
            this.speed = speed;
        }

        public void Move()
        {
            mTransform.position += direction * speed;
        }
    }
}
