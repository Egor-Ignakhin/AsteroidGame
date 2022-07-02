using System;

using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        public event Action<IPoolable> Realized;
        private Vector3 moveDirecton;
        private float speed = 10;

        public void Initialize(Vector3 moveDirecton)
        {
            this.moveDirecton = moveDirecton;
        }

        private void FixedUpdate()
        {
            transform.position += moveDirecton * speed;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirecton);
            if (hit.transform == null)
            {
                return;
            }

            if (hit.collider.TryGetComponent(out IBulletReceiver bulletReceiver))
            {
                bulletReceiver.Hit();
                Realize();
            }
        }

        public void Realize()
        {
            Realized?.Invoke(this);
        }
    }
}
