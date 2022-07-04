using Assets.Scripts.Bullets;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.UFO
{
    public class UfoBulletsPool : BulletsPool
    {
        public UfoBulletsPool(Transform objectsParent, 
            int objectsCount, PlayerInput playerInput) : base(objectsParent, objectsCount, playerInput)
        {
        }

        protected override void SetPrefabAsset()
        {
            prefabAsset = Resources.Load<Bullet>("UFOBullet");
        }
    }
}
