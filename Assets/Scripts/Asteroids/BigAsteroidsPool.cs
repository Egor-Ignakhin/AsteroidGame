using UnityEngine;

namespace Assets.Scripts.Asteroids
{
    public class BigAsteroidsPool : ObjectPool<BigAsteroid>
    {
        public BigAsteroidsPool(Transform objectsParent, int objectsCount) : base(objectsParent, objectsCount)
        {
        }

        protected override void SetPrefabAsset()
        {
            prefabAsset = Resources.Load<BigAsteroid>("BigAsteroid");
        }
    }
}
