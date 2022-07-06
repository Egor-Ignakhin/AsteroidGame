using System;
using Asteroids__Atari_.Scripts.Bullets;
using Asteroids__Atari_.Scripts.Player.Ship.ShipInput;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Player.Ship.Cannon
{
    public class ShipsCannon : MonoBehaviour, IBulletShooter
    {
        public event Action<IBulletReceiver> BulletHit;

        private IShipInput shipInput;

        private ObjectPool<Bullet> bulletsPool;

        [SerializeField] private Transform bulletsParent;
        [SerializeField] private Transform bulletInstantiatePlace;
        [SerializeField] private AudioSource fireAudioSource;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private ShipsCannonStats cannonStats;
        private static int maxShootsPerSecond;

        private void Awake()
        {
            bulletsPool = new BulletsPool(bulletsParent, 15, playerInput);
            maxShootsPerSecond = cannonStats.GetMaxShootsPerSecond();
        }

        public void SetShipInput(IShipInput ishipInput)
        {
            if (this.shipInput != null)
            {
                this.shipInput.ShootKeyDown -= Shoot;
            }

            this.shipInput = ishipInput;
            this.shipInput.ShootKeyDown += Shoot;
        }

        private void Shoot()
        {
            Bullet bullet = bulletsPool.GetObjectFromPool();
            bullet.Realized += OnBulletShot;

            bullet.transform.position = bulletInstantiatePlace.position;
            bullet.Initialize(transform.right, this);

            fireAudioSource.Play();
        }

        private void OnBulletShot(IPoolable poolable)
        {
            poolable.Realized -= OnBulletShot;

            Bullet bullet = (Bullet)poolable;

            var bulletReceiver = bullet.GetBulletReceiver();

            if (bulletReceiver != null)
            {
                BulletHit?.Invoke(bulletReceiver);
            }
        }

        public static int GetMaxShootsPerSecond()
        {
            return maxShootsPerSecond;
        }
    }
}
