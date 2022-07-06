using Asteroids__Atari_.Scripts.Player;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Asteroids
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
