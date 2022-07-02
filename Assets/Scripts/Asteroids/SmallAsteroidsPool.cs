using UnityEngine;

namespace Assets.Scripts.Asteroids
{
    public class SmallAsteroidsPool : ObjectPool<SmallAsteroid>
    {
        public SmallAsteroidsPool(Transform objectsParent, int objectsCount) : base(objectsParent, objectsCount)
        {
        }

        protected override void SetPrefabAsset()
        {
            prefabAsset = Resources.Load<SmallAsteroid>("SmallAsteroid");
        }
    }
}
