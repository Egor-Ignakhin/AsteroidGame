using UnityEngine;

namespace Assets.Scripts
{
    internal interface IBulletMotion
    {
        void Setup(Vector3 direction, float speed);
        void Move(ref Vector3 lastPositon);
    }
}