using Asteroids__Atari_.Scripts.Bullets;
using Asteroids__Atari_.Scripts.Player;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.UFO
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
