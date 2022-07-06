using UnityEngine;

namespace Asteroids__Atari_.Scripts.Blasts
{
    public class BlastBuilder : MonoBehaviour
    {
        private static ObjectPool<Blast> blastsPool;

        [SerializeField] private Transform blastsParent;

        private  void Awake()
        {
            blastsPool = new BlastsPool(blastsParent, 5);
        }

        public static void Build(Vector3 position)
        {
            var blast = blastsPool.GetObjectFromPool();

            blast.transform.position = position;
        }
    }
}
