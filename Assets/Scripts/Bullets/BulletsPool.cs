using Assets.Scripts.Bullets;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts
{
    public class BulletsPool : ObjectPool<Bullet>
    {
        public BulletsPool(Transform objectsParent,
            int objectsCount, PlayerInput playerInput) : base(objectsParent, objectsCount)
        {
            foreach (var bullet in reusableInstances)
            {
                bullet.Setup(playerInput);
            }
        }

        protected override void SetPrefabAsset()
        {
            prefabAsset = Resources.Load<Bullet>("Bullet");
        }
    }
}