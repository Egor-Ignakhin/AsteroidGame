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

        public void Initialize(Vector3 directon)
        {
            movedDistance = 0;
            this.directon = directon;
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
            if (hit.transform == null)
            {
                return;
            }

            if (hit.collider.TryGetComponent(out IBulletReceiver bulletReceiver))
            {
                bulletReceiver.Hit();
                Realized?.Invoke(this);
            }
        }
    }
}
