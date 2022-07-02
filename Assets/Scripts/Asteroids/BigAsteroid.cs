using System;

using UnityEngine;

namespace Assets.Scripts.Asteroids
{
    public class BigAsteroid : MonoBehaviour, IBaseAsteroid
    {
        public event Action<IPoolable> Realized;
        public event Action Destroyed;
        private float speed;
        private Vector3 direction;


        public void Initialize(float speed, Vector3 direction)
        {
            this.speed = speed;
            this.direction = direction;
        }

        private void FixedUpdate()
        {
            transform.position += direction * speed;
        }

        public void Hit()
        {
            DestroyAsteroid();
        }

        private void DestroyAsteroid()
        {
            Destroyed?.Invoke();
        }
    }
}
