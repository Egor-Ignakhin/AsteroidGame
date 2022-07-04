using System;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        public event Action<IPoolable> Realized;

        private IBulletShooter bulletShooter;
        private IBulletReceiver bulletReceiver;
        private PlayerInput playerInput;

        private IBulletMotion currentBulletMotion;
        private IBulletMotion mainBulletMotion;
        private IBulletMotion pausedBulletMotion;
        
        private BulletCollisionChecker collisionChecker;

        public void Setup(PlayerInput playerInput)
        {
            this.playerInput = playerInput;

            mainBulletMotion = new MainBulletMotion(transform);
            pausedBulletMotion = new PausedBulletMotion();
            collisionChecker = new BulletCollisionChecker(transform);
            collisionChecker.Collided += OnCollided;
            mainBulletMotion.MovementIsOver += OnMovementIsOver;

            playerInput.Paused += OnPaused;
            OnPaused();
        }

        private void OnCollided(IBulletReceiver receiver)
        {
            this.bulletReceiver = receiver;
            this.bulletReceiver.Hit(bulletShooter);
            Realized?.Invoke(this);
        }

        private void OnMovementIsOver()
        {
            Realized?.Invoke(this);
        }

        private void OnPaused()
        {
            currentBulletMotion = playerInput.IsPaused() ?
                pausedBulletMotion : mainBulletMotion;
        }

        public void Initialize(Vector3 direction, IBulletShooter shooter)
        {
            bulletShooter = shooter;
            mainBulletMotion.Initialize(direction, 10);
            collisionChecker.Initialize(shooter, direction);
        }

        private void FixedUpdate()
        {
            currentBulletMotion.Move();

            collisionChecker.Update();
        }

        public IBulletReceiver GetBulletReceiver()
        {
            return bulletReceiver;
        }

        private void OnDestroy()
        {
            collisionChecker.Collided -= OnCollided;
        }
    }
}
