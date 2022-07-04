using Assets.Scripts.Asteroids.AsteroidMovement;
using Assets.Scripts.Player;

using System;

using UnityEngine;

namespace Assets.Scripts.Asteroids
{
    public abstract class BaseAsteroid : MonoBehaviour, IBulletReceiver, IPoolable, IDestroyable
    {
        public event Action<IDestroyable> Destroyed;
        public event Action<BaseAsteroid> FullDestroyed;
        public event Action<IPoolable> Realized;

        public const float MinSpeed = 1;
        public const float MaxSpeed = 5;

        private Vector3 direction;

        private PlayerInput playerInput;
        private IAsteroidMovement currentAsteroidMovement;
        private IAsteroidMovement mainAsteroidMovement;
        private IAsteroidMovement pausedAsteroidMovement;

        public Vector3 Direction()
        {
            return direction;
        }

        private void Awake()
        {
            mainAsteroidMovement = new MainAsteroidMovement(transform);
            pausedAsteroidMovement = new PausedAsteroidMovement();
        }

        public void Setup(PlayerInput playerInput)
        {
            this.playerInput = playerInput;

            playerInput.Paused += OnPaused;
            OnPaused();
        }

        private void OnPaused()
        {
            currentAsteroidMovement = playerInput.IsPaused() ?
                pausedAsteroidMovement : mainAsteroidMovement;
        }

        public void Initialize(float speed, Vector3 direction)
        {
            this.direction = direction;

            mainAsteroidMovement.Inititalize(direction, speed);
            pausedAsteroidMovement.Inititalize(direction, speed);
        }

        private void FixedUpdate()
        {
            currentAsteroidMovement.Move();
        }

        public void Hit(IBulletShooter _)
        {
            Divide();
        }

        private void Divide()
        {
            Realized?.Invoke(this);
            Destroyed?.Invoke(this);
            BlastBuilder.Build(transform.position);
        }

        public void Destroy()
        {
            Realized?.Invoke(this);
            FullDestroyed?.Invoke(this);
            BlastBuilder.Build(transform.position);
        }

        private void OnDestroy()
        {
            playerInput.Paused -= OnPaused;
        }
    }
}
