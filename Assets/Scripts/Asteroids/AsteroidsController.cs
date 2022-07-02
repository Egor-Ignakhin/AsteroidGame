using System.Collections;

using UnityEngine;

using Random = UnityEngine.Random;

namespace Assets.Scripts.Asteroids
{
    public class AsteroidsController : MonoBehaviour
    {
        [SerializeField] private Transform asteroidsParent;
        private ObjectPool<BigAsteroid> bigAsteroidsPool;
        private ObjectPool<MediumAsteroid> mediumAsteroidsPool;
        private ObjectPool<SmallAsteroid> smallAsteroidsPool;

        private int asteroidsWave;

        private void Awake()
        {
            bigAsteroidsPool = new BigAsteroidsPool(asteroidsParent, 15);
            mediumAsteroidsPool = new MediumAsteroidsPool(asteroidsParent, 15);
            smallAsteroidsPool = new SmallAsteroidsPool(asteroidsParent, 15);
        }

        private void Start()
        {
            StartCoroutine(ReCreateAsteroids(0));
        }

        private IEnumerator ReCreateAsteroids(float waiting)
        {
            yield return new WaitForSeconds(waiting);
            for (int i = 0; i < 2 + asteroidsWave; i++)
            {
                CreateBigAsteroid(new Vector3(Random.Range(0, Screen.width),
                    Random.Range(0, Screen.height)),
                    Random.Range(BaseAsteroid.MinSpeed, BaseAsteroid.MaxSpeed));
            }
        }

        private void CreateBigAsteroid(Vector3 position, float speed)
        {
            var asteroid = bigAsteroidsPool.GetObjectFromPool();

            asteroid.transform.position = position;
            Vector3 direction = Random.insideUnitCircle.normalized;
            asteroid.Initialize(speed, direction);

            asteroid.Destroyed += OnAsteroidDestroy;
        }

        private void OnAsteroidDestroy(BaseAsteroid asteroid)
        {
            var leftDir = asteroid.Direction();
            var rightDir = asteroid.Direction();

            var angle = 45 * Mathf.Deg2Rad;
            leftDir.x = leftDir.x * Mathf.Cos(angle) + leftDir.y * Mathf.Sin(angle);
            leftDir.y = leftDir.y * Mathf.Cos(angle) - leftDir.x * Mathf.Sin(angle);

            rightDir.x = rightDir.x * Mathf.Cos(-angle) + rightDir.y * Mathf.Sin(-angle);
            rightDir.y = rightDir.y * Mathf.Cos(-angle) - rightDir.x * Mathf.Sin(-angle);

            var speed = Random.Range(BaseAsteroid.MinSpeed, BaseAsteroid.MaxSpeed);

            if (asteroid is BigAsteroid bigAsteroid)
            {
                CreateMediumAsteroid(asteroid.transform.position, leftDir, speed);
                CreateMediumAsteroid(asteroid.transform.position, rightDir, speed);
            }
            else if (asteroid is MediumAsteroid mediumAsteroid)
            {
                CreateSmallAsteroid(asteroid.transform.position, leftDir, speed);
                CreateSmallAsteroid(asteroid.transform.position, rightDir, speed);
            }

            asteroid.Destroyed -= OnAsteroidDestroy;

            if (bigAsteroidsPool.InUsing() == 0 &&
                mediumAsteroidsPool.InUsing() == 0 &&
                smallAsteroidsPool.InUsing() == 0)
            {
                asteroidsWave++;
                StartCoroutine(ReCreateAsteroids(2));
            }
        }

        private void CreateMediumAsteroid(Vector3 position, Vector3 direction, float speed)
        {
            var asteroid = mediumAsteroidsPool.GetObjectFromPool();

            asteroid.transform.position = position;
            asteroid.Initialize(speed, direction);

            asteroid.Destroyed += OnAsteroidDestroy;
        }

        private void CreateSmallAsteroid(Vector3 position, Vector3 direction, float speed)
        {
            var asteroid = smallAsteroidsPool.GetObjectFromPool();

            asteroid.transform.position = position;
            asteroid.Initialize(speed, direction);

            asteroid.Destroyed += OnAsteroidDestroy;
        }
    }
}
