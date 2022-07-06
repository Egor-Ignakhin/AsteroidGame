using System;
using Asteroids__Atari_.Scripts.Bullets.Movement;
using Asteroids__Atari_.Scripts.Player;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Bullets
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        public event Action<IPoolable> Realized;

        private IBulletShooter bulletShooter;
        private IBulletReceiver bulletReceiver;
        private PlayerInput playerInput;

        private IBulletMovement currentBulletMovement;
        private IBulletMovement mainBulletMovement;
        private IBulletMovement pausedBulletMovement;
        
        private BulletCollisionChecker collisionChecker;

        public void Setup(PlayerInput playerInput)
        {
            this.playerInput = playerInput;

            mainBulletMovement = new MainBulletMovement(transform);
            pausedBulletMovement = new PausedBulletMovement();
            collisionChecker = new BulletCollisionChecker(transform);
            collisionChecker.Collided += OnCollided;
            mainBulletMovement.MovementIsOver += OnMovementIsOver;

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
            currentBulletMovement = playerInput.IsPaused() ?
                pausedBulletMovement : mainBulletMovement;
        }

        public void Initialize(Vector3 direction, IBulletShooter shooter)
        {
            bulletShooter = shooter;
            mainBulletMovement.Initialize(direction, 10);
            collisionChecker.Initialize(shooter, direction);
        }

        private void FixedUpdate()
        {
            currentBulletMovement.Move();

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
