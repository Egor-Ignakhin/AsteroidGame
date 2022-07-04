using System;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class BulletCollisionChecker
    {
        private readonly Transform transform;
        public event Action<IBulletReceiver> Collided;
        private IBulletShooter bulletShooter;
        private Vector3 bulletDirection;

        public BulletCollisionChecker(Transform transform)
        {
            this.transform = transform;
        }

        public void Initialize(IBulletShooter shooter, Vector3 direction)
        {
            this.bulletShooter = shooter;
            this.bulletDirection = direction;
        }

        public void Update()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, bulletDirection, 0.1f);
            if (hit.transform == null
                || hit.transform.GetComponent<IBulletShooter>() == bulletShooter)
            {
                return;
            }

            if (hit.collider.TryGetComponent(out IBulletReceiver receiver))
            {
                Collided?.Invoke(receiver);
            }
        }
    }
}
