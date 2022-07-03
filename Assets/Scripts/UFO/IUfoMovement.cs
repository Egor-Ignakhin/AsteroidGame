using UnityEngine;

namespace Assets.Scripts.UFO
{
    internal interface IUfoMovement
    {
        void Move();
        void Initialize(Vector3 startPosition, Vector3 targetPosition);
    }
}