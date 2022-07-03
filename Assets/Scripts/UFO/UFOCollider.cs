using System;
using UnityEngine;

namespace Assets.Scripts.UFO
{
    public class UFOCollider : MonoBehaviour, IBulletReceiver
    {
        public event Action<IDestroyable> DestroyableContacted;
        public event Action<IBulletShooter> bulletReceived;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent(out IDestroyable destroyable))
            {
                DestroyableContacted?.Invoke(destroyable);
            }
        }

        public void Hit(IBulletShooter shooter)
        {
            bulletReceived?.Invoke(shooter);
        }
    }
}
