using UnityEngine;

namespace Assets.Scripts
{
    public class BlastsPool : ObjectPool<Blast>
    {
        public BlastsPool(Transform objectsParent, int objectsCount) : base(objectsParent, objectsCount)
        {
        }

        protected override void SetPrefabAsset()
        {
            prefabAsset = Resources.Load<Blast>("Blast");
        }
    }
}
