using Asteroids__Atari_.Scripts.Player;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Asteroids
{
    public class AsteroidsPool<T> : ObjectPool<T> where T : Asteroid
    {
        public AsteroidsPool(Transform objectsParent,
            int objectsCount, PlayerInput playerInput) : base(objectsParent, objectsCount)
        {
            foreach (var asteroid in reusableInstances)
            {
                asteroid.Setup(playerInput);
            }
        }

        protected override void SetPrefabAsset()
        {
            throw new System.NotImplementedException();
        }
    }
}
