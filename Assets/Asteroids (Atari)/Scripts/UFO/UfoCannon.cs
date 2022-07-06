using Asteroids__Atari_.Scripts.Bullets;
using Asteroids__Atari_.Scripts.Player;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.UFO
{
    public class UfoCannon : MonoBehaviour, IBulletShooter
    {
        private ObjectPool<Bullet> bulletsPool;
        private Transform playerShipTransform;
        private float delayShooting;


        public void Setup(Transform playerShipTransform,
            Transform bulletsParent, PlayerInput playerInput)
        {
            this.playerShipTransform = playerShipTransform;

            bulletsPool = new UfoBulletsPool(bulletsParent, 10, playerInput);

        }

        public void Shoot()
        {
            Bullet bullet = bulletsPool.GetObjectFromPool();
            bullet.transform.position = transform.position;
            bullet.Initialize((playerShipTransform.position - transform.position).normalized, this);
        }

        public void TryShoot()
        {
            if (delayShooting < 0)
            {
                delayShooting = Random.Range(2f, 5f);

                Shoot();
            }

            delayShooting -= Time.deltaTime;
        }
    }
}
