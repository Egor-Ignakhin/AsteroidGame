using UnityEngine;

namespace Assets.Scripts.Asteroids
{
    public class AsteroidsController : MonoBehaviour
    {
        [SerializeField] private Transform asteroidsParent;
        private BigAsteroidsPool bigAsteroidsPool;
        private MediumAsteroidsPool mediumAsteroidsPool;
        private SmallAsteroidsPool smallAsteroidsPool;

        private void Awake()
        {
            bigAsteroidsPool = new BigAsteroidsPool(asteroidsParent, 15);
            mediumAsteroidsPool = new MediumAsteroidsPool(asteroidsParent, 15);
            smallAsteroidsPool = new SmallAsteroidsPool(asteroidsParent, 15);
        }

        private void Start()
        {
            CreateBigAsteroid();
            CreateBigAsteroid();
        }

        private void CreateBigAsteroid()
        {
            var asteroid = bigAsteroidsPool.GetObjectFromPool();

            asteroid.transform.position = new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
            Vector3 direction = Random.insideUnitCircle.normalized;
            asteroid.Initialize(1, direction);
        }
    }
}
