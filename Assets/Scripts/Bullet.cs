using System;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        public event Action<IPoolable> Realized;
        private Vector3 directon;
        private float movedDistance;
        private IBulletShooter shooter;
        private IBulletReceiver receiver;
        private PlayerInput playerInput;
        private Vector3 lastPostion;
        private IBulletMotion currentBulletMotion;
        private IBulletMotion mainBulletMotion;
        private IBulletMotion pausedBulletMotion;

        public void Setup(PlayerInput playerInput)
        {
            this.playerInput = playerInput;

            mainBulletMotion = new MainBulletMotion(transform);
            pausedBulletMotion = new PausedBulletMotion();

            playerInput.Paused += OnPaused;
            OnPaused();
        }

        private void OnPaused()
        {
            currentBulletMotion = playerInput.IsPaused() ? pausedBulletMotion : mainBulletMotion;
        }

        public void Initialize(Vector3 directon, IBulletShooter shooter)
        {
            movedDistance = 0;
            this.directon = directon;
            this.shooter = shooter;

            mainBulletMotion.Setup(directon, 10);
        }

        private void FixedUpdate()
        {
            currentBulletMotion.Move(ref lastPostion);

            ThrowRay();

            TakeStatistics();
        }

        private void ThrowRay()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directon, 0.1f);
            if (hit.transform == null
                || hit.transform.GetComponent<IBulletShooter>() == shooter)
            {
                return;
            }

            if (hit.collider.TryGetComponent(out IBulletReceiver receiver))
            {
                this.receiver = receiver;
                this.receiver.Hit(shooter);
                Realized?.Invoke(this);
            }
        }

        private void TakeStatistics()
        {
            movedDistance += Vector3.Distance(lastPostion, transform.position);

            if (movedDistance > Screen.width)
            {
                Realized?.Invoke(this);
            }
        }

        public IBulletReceiver GetBulletReceiver()
        {
            return receiver;
        }
    }
}
