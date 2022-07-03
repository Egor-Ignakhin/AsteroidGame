using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Asteroids
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
