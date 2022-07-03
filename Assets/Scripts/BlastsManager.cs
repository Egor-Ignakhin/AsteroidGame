using UnityEngine;

namespace Assets.Scripts
{
    public class BlastsManager : MonoBehaviour
    {
        private static ObjectPool<Blast> blastsPool;

        [SerializeField] private Transform blastsParent;

        private  void Awake()
        {
            blastsPool = new BlastsPool(blastsParent, 5);
        }

        public static void Blast(Vector3 position)
        {
            var blast = blastsPool.GetObjectFromPool();

            blast.transform.position = position;
        }
    }
}
