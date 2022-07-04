using Assets.Scripts.Asteroids.AsteroidMovement;
using Assets.Scripts.Player;

using System;
using Assets.Scripts.Blasts;
using Assets.Scripts.Bullets;
using UnityEngine;

namespace Assets.Scripts.Asteroids
{
    public abstract class Asteroid : MonoBehaviour, IBulletReceiver, IPoolable, IDestroyable
    {
        public event Action<IDestroyable> Destroyed;
        public event Action<Asteroid> FullDestroyed;
        public event Action<IPoolable> Realized;

        public const float MinSpeed = 1;
        public const float MaxSpeed = 5;

        private Vector3 asteroidDirection;

        private PlayerInput playerInput;
        private IAsteroidMovement currentAsteroidMovement;
        private IAsteroidMovement mainAsteroidMovement;
        private IAsteroidMovement pausedAsteroidMovement;

        public Vector3 Direction()
        {
            return asteroidDirection;
        }

        private void Awake()
        {
            mainAsteroidMovement = new MainAsteroidMovement(transform);
            pausedAsteroidMovement = new PausedAsteroidMovement();
        }

        public void Setup(PlayerInput pInput)
        {
            this.playerInput = pInput;

            pInput.Paused += OnPaused;
            OnPaused();
        }

        private void OnPaused()
        {
            currentAsteroidMovement = playerInput.IsPaused() ?
                pausedAsteroidMovement : mainAsteroidMovement;
        }

        public void Initialize(float speed, Vector3 direction)
        {
            this.asteroidDirection = direction;

            mainAsteroidMovement.Initialize(direction, speed);
            pausedAsteroidMovement.Initialize(direction, speed);
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
