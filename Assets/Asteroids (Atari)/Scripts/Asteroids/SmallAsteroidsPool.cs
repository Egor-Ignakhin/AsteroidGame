using Asteroids__Atari_.Scripts.Player;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Asteroids
{
    public class SmallAsteroidsPool : AsteroidsPool<SmallAsteroid>
    {
        public SmallAsteroidsPool(Transform objectsParent,
            int objectsCount, PlayerInput playerInput) : base(objectsParent, objectsCount, playerInput)
        {
        }

        protected override void SetPrefabAsset()
        {
            prefabAsset = Resources.Load<SmallAsteroid>("SmallAsteroid");
        }
    }
}
