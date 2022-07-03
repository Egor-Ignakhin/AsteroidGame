using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.UFO
{
    public class UFOBulletsPool : BulletsPool
    {
        public UFOBulletsPool(Transform objectsParent, 
            int objectsCount, PlayerInput playerInput) : base(objectsParent, objectsCount, playerInput)
        {
        }

        protected override void SetPrefabAsset()
        {
            prefabAsset = Resources.Load<Bullet>("UFOBullet");
        }
    }
}
