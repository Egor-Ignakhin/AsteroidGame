using UnityEngine;

namespace Assets.Scripts.UFO
{
    public class UFOBulletsPool : ObjectPool<Bullet>
    {
        public UFOBulletsPool(Transform objectsParent, int objectsCount) : base(objectsParent, objectsCount)
        {
        }

        protected override void SetPrefabAsset()
        {
            prefabAsset = Resources.Load<Bullet>("UFOBullet");
        }
    }
}
