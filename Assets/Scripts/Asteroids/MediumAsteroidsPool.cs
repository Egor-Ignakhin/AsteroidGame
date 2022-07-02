using UnityEngine;

namespace Assets.Scripts.Asteroids
{
    public class MediumAsteroidsPool : ObjectPool<MediumAsteroid>
    {
        public MediumAsteroidsPool(Transform objectsParent, int objectsCount) : base(objectsParent, objectsCount)
        {
        }

        protected override void SetPrefabAsset()
        {
            prefabAsset = Resources.Load<MediumAsteroid>("MediumAsteroid");
        }
    }
}
