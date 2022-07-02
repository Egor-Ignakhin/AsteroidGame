using System;
using System.Collections;
using System.Threading.Tasks;

using UnityEngine;

using Random = UnityEngine.Random;

namespace Assets.Scripts.UFO
{
    public class UFOController : MonoBehaviour
    {
        public event Action Realized;

        private ObjectPool<Bullet> ufoBulletsPool;
        private Transform playerShipTransform;

        public void Setup(Transform bulletsParent, Transform playerTransform)
        {
            ufoBulletsPool = new UFOBulletsPool(bulletsParent, 10);
            this.playerShipTransform = playerTransform;
        }

        public async void Initialize(Vector3 positon, Vector3 target)
        {
            transform.position = positon;

            float timeSpeed = 10f;

            StartCoroutine(timeSpeed.Tweeng((p) => transform.position = p,
                positon,
                target));

            StartCoroutine(nameof(Shooting));
            await Task.Delay((int)(1000 * timeSpeed));
            if (gameObject != null)
            {
                StopAllCoroutines();
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
                bullet.Initialize((playerShipTransform.position - transform.position).normalized);
            }
        }
    }
}
