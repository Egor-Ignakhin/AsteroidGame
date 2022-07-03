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

        public void Setup(Transform bulletsParent, Transform playerTransform)
        {
            ufoBulletsPool = new UFOBulletsPool(bulletsParent, 10);
            this.playerShipTransform = playerTransform;
            ufoCollider.DestroyableContacted += OnDestroyableContacted;
            ufoCollider.bulletReceived += OnBulletReceived;
        }

        private void OnDestroyableContacted(IDestroyable obj)
        {
            FullDestroy();
        }

        private void OnBulletReceived(IBulletShooter shooter)
        {
            FullDestroy();

        }

        public void Initialize(Vector3 positon, Vector3 target)
        {
            StartCoroutine(nameof(Shooting));
            StartCoroutine(Realizing(positon, target));
        }

        private IEnumerator Realizing(Vector3 positon, Vector3 target)
        {
            float targetTime = 10f;

            yield return StartCoroutine(targetTime.Tweeng((p) => transform.position = p,
                positon,
                target));

            Realized?.Invoke();
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
