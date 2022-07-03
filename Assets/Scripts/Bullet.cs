using System;

using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        public event Action<IPoolable> Realized;
        private Vector3 directon;
        private float speed = 10;
        private float movedDistance;
        private IBulletShooter shooter;
        private  IBulletReceiver receiver;

        public void Initialize(Vector3 directon, IBulletShooter shooter)
        {
            movedDistance = 0;
            this.directon = directon;
            this.shooter = shooter;
        }

        private void FixedUpdate()
        {
            Vector3 lastPostion = transform.position;
            transform.position += directon * speed;

            ThrowRay();

            movedDistance += Vector3.Distance(lastPostion, transform.position);

            if (movedDistance > Screen.width)
                Realized?.Invoke(this);
        }

        private void ThrowRay()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directon, 0.1f);
            if (hit.transform == null 
                || hit.transform.GetComponent<IBulletShooter>() == shooter)
            {
                return;
            }

            if (hit.collider.TryGetComponent(out IBulletReceiver receiver))
            {
                this.receiver = receiver;
                this.receiver.Hit(shooter);
                Realized?.Invoke(this);
            }
        }

        public IBulletReceiver GetBulletReceiver()
        {
            return receiver;
        }
    }
}
