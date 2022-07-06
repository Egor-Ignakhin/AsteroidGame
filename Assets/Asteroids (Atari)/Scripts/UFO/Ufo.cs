using System;
using Asteroids__Atari_.Scripts.Blasts;
using Asteroids__Atari_.Scripts.Bullets;
using Asteroids__Atari_.Scripts.Player;
using Asteroids__Atari_.Scripts.UFO.Movement;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.UFO
{
    public class Ufo : MonoBehaviour, IDestroyable
    {
        public event Action<IDestroyable> Destroyed;
        public event Action Realized;

        [SerializeField] private UfoCollider mCollider;
        private PlayerInput playerInput;

        private IUfoMovement currentUfoMovement;
        private IUfoMovement mainUfoMovement;
        private IUfoMovement pausedUfoMovement;

        [SerializeField] private UfoCannon ufoCannon;

        public void Setup(Transform bulletsParent, Transform playerShipTransform, PlayerInput playerInput)
        {
            this.playerInput = playerInput;

            mainUfoMovement = new MainUfoMovement(transform);
            pausedUfoMovement = new PausedUfoMovement();
            ufoCannon.Setup(playerShipTransform, bulletsParent, playerInput);

            this.playerInput.Paused += OnPaused;
            OnPaused();

            mCollider.DestroyableContacted += OnDestroyableContacted;
            mCollider.bulletReceived += OnBulletReceived;
            mainUfoMovement.MovementIsOver += OnMovementIsOver;
        }

        private void OnMovementIsOver()
        {
            Realized?.Invoke();
        }

        private void OnPaused()
        {
            currentUfoMovement = playerInput.IsPaused() ? pausedUfoMovement : mainUfoMovement;
        }

        private void OnDestroyableContacted(IDestroyable obj)
        {
            Destroy();
        }

        private void OnBulletReceived(IBulletShooter shooter)
        {
            if (shooter as UfoCannon == ufoCannon)
            {
                return;
            }
            Destroy();
        }

        public void Initialize(Vector3 position, Vector3 target)
        {
            transform.position = position;
            mainUfoMovement.Initialize(position, target);
        }

        private void FixedUpdate()
        {
            currentUfoMovement.Move();
        }

        private void Update()
        {
            ufoCannon.TryShoot();
        }

        public void Destroy()
        {
            StopAllCoroutines();
            Realized?.Invoke();
            BlastBuilder.Build(transform.position);
        }

        private void OnDestroy()
        {
            mCollider.DestroyableContacted -= OnDestroyableContacted;
            mCollider.bulletReceived -= OnBulletReceived;
        }
    }
}
