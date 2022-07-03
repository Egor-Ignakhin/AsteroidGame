using Assets.Scripts.Player;

using System;
using System.Collections;

using UnityEngine;

using Random = UnityEngine.Random;

namespace Assets.Scripts.UFO
{
    public class UFOController : MonoBehaviour, IDestroyable, IBulletShooter
    {
        public event Action<IDestroyable> Destroyed;
        public event Action Realized;

        private ObjectPool<Bullet> ufoBulletsPool;
        private Transform playerShipTransform;
        [SerializeField] private UFOCollider ufoCollider;
        private PlayerInput playerInput;
        private Vector3 targetPosition;

        private IUfoMovement currentUfoMovement;
        private IUfoMovement mainUfoMovement;
        private IUfoMovement pausedUfoMovement;

        public void Setup(Transform bulletsParent, Transform playerTransform, PlayerInput playerInput)
        {
            this.playerInput = playerInput;
            ufoBulletsPool = new UFOBulletsPool(bulletsParent, 10, playerInput);
            this.playerShipTransform = playerTransform;

            mainUfoMovement = new MainUfoMovement(transform);
            pausedUfoMovement = new PausedUfoMovement();

            this.playerInput.Paused += OnPaused;
            OnPaused();

            ufoCollider.DestroyableContacted += OnDestroyableContacted;
            ufoCollider.bulletReceived += OnBulletReceived;
        }

        private void OnPaused()
        {
            currentUfoMovement = playerInput.IsPaused() ? pausedUfoMovement : mainUfoMovement;
        }

        private void OnDestroyableContacted(IDestroyable obj)
        {
            FullDestroy();
        }

        private void OnBulletReceived(IBulletShooter shooter)
        {
            FullDestroy();
        }

        public void Initialize(Vector3 position, Vector3 target)
        {
            StartCoroutine(nameof(Shooting));
            transform.position = position;
            targetPosition = target;
            mainUfoMovement.Initialize(position, target);
        }

        private void Update()
        {
            currentUfoMovement.Move();

            TakeStatistics();
        }

        private void TakeStatistics()
        {
            if (transform.position == targetPosition)
            {
                Realized?.Invoke();
            }
        }

        private IEnumerator Shooting()
        {
            while (true)
            {
                float delay = Random.Range(2f, 5f);
                yield return new WaitForSeconds(delay);

                Bullet bullet = ufoBulletsPool.GetObjectFromPool();
                bullet.transform.position = transform.position;
                bullet.Initialize((playerShipTransform.position - transform.position).normalized, this);
            }
        }


        public void FullDestroy()
        {
            StopAllCoroutines();
            Realized?.Invoke();
            BlastsManager.Blast(transform.position);
        }

        private void OnDestroy()
        {
            ufoCollider.DestroyableContacted -= OnDestroyableContacted;
            ufoCollider.bulletReceived -= OnBulletReceived;
        }
    }
}
