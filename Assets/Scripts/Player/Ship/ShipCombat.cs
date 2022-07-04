using System;
using Assets.Scripts.Bullets;
using UnityEngine;

namespace Assets.Scripts.Player.Ship
{//TODO: cut class on gun and gun controller
    public class ShipCombat : MonoBehaviour, IBulletShooter
    {
        public event Action<IBulletReceiver> BulletHited;
        private IShipInput shipInput;
        private BulletsPool bulletsPool;
        [SerializeField] private Transform bulletsParent;
        [SerializeField] private Transform bulletsInstantiatePlace;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private  PlayerInput playerInput;

        private void Awake()
        {
            bulletsPool = new BulletsPool(bulletsParent, 15, playerInput);
        }

        public void SetShipInput(IShipInput shipInput)
        {
            if (this.shipInput != null)
            {
                this.shipInput.ShootKeyDown -= OnShootKeyDown;
            }

            this.shipInput = shipInput;
            this.shipInput.ShootKeyDown += OnShootKeyDown;
        }

        private void OnShootKeyDown()
        {
            Bullet bullet = bulletsPool.GetObjectFromPool();
            bullet.Realized += OnShootedBulletRealized;

            bullet.transform.position = bulletsInstantiatePlace.position;
            bullet.Initialize(transform.right, this);

            audioSource.Play();
        }

        private void OnShootedBulletRealized(IPoolable poolable)
        {
            poolable.Realized -= OnShootedBulletRealized;

            Bullet bullet = (Bullet)poolable;

            var bulletReceiver = bullet.GetBulletReceiver();

            if (bulletReceiver != null)
                BulletHited?.Invoke(bulletReceiver);
        }
    }
}
