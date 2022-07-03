using System;
using Assets.Scripts.Player.Ship;
using UnityEngine;

namespace Assets.Scripts.Asteroids
{
    public abstract class BaseAsteroid : MonoBehaviour, IBulletReceiver, IPoolable, IDestroyable
    {
        public event Action<IDestroyable> Destroyed;
        public event Action<BaseAsteroid> FullDestroyed;
        public event Action<IPoolable> Realized;

        private float speed;
        public const float MinSpeed = 1;
        public  const float MaxSpeed = 5;

        private Vector3 direction;


        public Vector3 Direction()
        {
            return direction;
        }

        public void Initialize(float speed, Vector3 direction)
        {
            this.speed = speed;
            this.direction = direction;
        }

        private void FixedUpdate()
        {
            transform.position += direction * speed;
        }

        public void Hit(IBulletShooter _)
        {
            Destroy();
        }

        private void Destroy()
        {
            Realized?.Invoke(this);
            Destroyed?.Invoke(this);
            BlastsManager.Blast(transform.position);
        }

        public void FullDestroy()
        {
            Realized?.Invoke(this);
            FullDestroyed?.Invoke(this);
            BlastsManager.Blast(transform.position);
        }
    }
}
