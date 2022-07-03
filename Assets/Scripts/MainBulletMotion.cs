using UnityEngine;

namespace Assets.Scripts
{
    public class MainBulletMotion : IBulletMotion
    {
        private readonly Transform mTransform;
        private Vector3 direction;
        private float speed;

        public MainBulletMotion(Transform transform)
        {
            mTransform = transform;
        }

        public void Setup(Vector3 direction, float speed)
        {
            this.direction = direction;
            this.speed = speed;
        }

        public void Move(ref Vector3 lastPostion)
        {
            lastPostion = mTransform.position;
            mTransform.position += direction * speed;
        }
    }
}