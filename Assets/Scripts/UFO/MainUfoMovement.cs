using UnityEngine;

namespace Assets.Scripts.UFO
{
    public class MainUfoMovement : IUfoMovement
    {
        private Transform mTransform;
        private Vector3 targetPosition;
        private Vector3 startPosition;
        private float time;

        public MainUfoMovement(Transform mTransform)
        {
            this.mTransform = mTransform;
        }

        public void Initialize(Vector3 startPosition, Vector3 targetPosition)
        {
            this.startPosition = startPosition;
            this.targetPosition = targetPosition;

            time = 0;
        }

        public void Move()
        {
            time += Time.deltaTime / 10f;
            mTransform.position = Vector3.Lerp(startPosition, targetPosition, time);
        }
    }
}