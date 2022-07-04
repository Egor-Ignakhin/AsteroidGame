using UnityEngine;

namespace Assets.Scripts.Asteroids.AsteroidMovement
{
    public interface IAsteroidMovement
    {
        void Initialize(Vector3 direction, float speed);
        void Move();
    }
}
