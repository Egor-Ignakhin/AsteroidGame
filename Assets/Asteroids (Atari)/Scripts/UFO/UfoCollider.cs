using System;
using Asteroids__Atari_.Scripts.Bullets;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.UFO
{
    public class UfoCollider : MonoBehaviour, IBulletReceiver
    {
        public event Action<IDestroyable> DestroyableContacted;
        public event Action<IBulletShooter> bulletReceived;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.TryGetComponent(out IDestroyable destroyable))
            {
                return;
            }

            DestroyableContacted?.Invoke(destroyable);
        }

        public void Hit(IBulletShooter shooter)
        {
            bulletReceived?.Invoke(shooter);
        }
    }
}
