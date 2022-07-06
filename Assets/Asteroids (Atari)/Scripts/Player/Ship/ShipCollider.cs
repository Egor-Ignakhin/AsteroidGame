using System;
using Asteroids__Atari_.Scripts.Bullets;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Player.Ship
{
    public class ShipCollider : MonoBehaviour, IBulletReceiver
    {
        public event Action<IDestroyable> DestroyableContacted;
        public event Action BulletReceived;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent(out IDestroyable destroyable))
            {
                DestroyableContacted?.Invoke(destroyable);
            }
        }

        public void Hit(IBulletShooter _)
        {
            BulletReceived?.Invoke();
        }
    }
}
