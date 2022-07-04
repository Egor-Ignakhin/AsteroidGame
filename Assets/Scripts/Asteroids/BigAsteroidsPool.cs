using Assets.Scripts.Player;

using UnityEngine;

namespace Assets.Scripts.Asteroids
{
    public class BigAsteroidsPool : AsteroidsPool<BigAsteroid>
    {
        public BigAsteroidsPool(Transform objectsParent,
            int objectsCount, PlayerInput playerInput) : base(objectsParent, objectsCount, playerInput)
        {
        }

        protected override void SetPrefabAsset()
        {
            prefabAsset = Resources.Load<BigAsteroid>("BigAsteroid");
        }
    }
}
