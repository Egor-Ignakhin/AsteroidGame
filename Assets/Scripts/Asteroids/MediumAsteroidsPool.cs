using Assets.Scripts.Player;

using UnityEngine;

namespace Assets.Scripts.Asteroids
{
    public class MediumAsteroidsPool : AsteroidsPool<MediumAsteroid>
    {
        public MediumAsteroidsPool(Transform objectsParent,
            int objectsCount, PlayerInput playerInput) : base(objectsParent, objectsCount, playerInput)
        {
        }

        protected override void SetPrefabAsset()
        {
            prefabAsset = Resources.Load<MediumAsteroid>("MediumAsteroid");
        }
    }
}
