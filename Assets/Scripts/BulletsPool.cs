using UnityEngine;

namespace Assets.Scripts
{
    public class BulletsPool : ObjectPool<Bullet>
    {
        public BulletsPool(Transform objectsParent, int objectsCount) : base(objectsParent, objectsCount)
        {
        }

        protected override void SetPrefabAsset()
        {
            prefabAsset = Resources.Load<Bullet>("Bullet");
        }
    }
}
