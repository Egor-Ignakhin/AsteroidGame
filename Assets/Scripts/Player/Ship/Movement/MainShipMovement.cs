using UnityEngine;

namespace Assets.Scripts.Player.Ship.Movement
{
    public class MainShipMovement : ShipMovement
    {
        private readonly float movingSpeed;
        private readonly float rotationSpeed;
        private readonly float movingInertia;
        private readonly float rotationInertia;

        public MainShipMovement(Transform t, AudioSource audioSource,
            float movingSpeed, float rotationSpeed, float movingInertia, float rotationInertia) : base(t, audioSource)
        {
            this.movingSpeed = movingSpeed;
            this.rotationSpeed = rotationSpeed;
            this.movingInertia = movingInertia;
            this.rotationInertia = rotationInertia;
        }

        protected override void MovingKeysPressed()
        {
            moveVelocity = mTransform.right * shipInput.GetMoveSign() * Time.deltaTime * 100;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        protected override void RotationKeysPressed()
        {
            rotateVelocity = mTransform.forward * shipInput.GetRotationSign() * Time.deltaTime * 100;
        }

        protected override void OnMouseMoved()
        {
            Vector2 positionOnScreen = mTransform.position;

            Vector2 mouseOnScreen = Input.mousePosition;

            var direction = mouseOnScreen - positionOnScreen;

            var _targetRotation = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

            rotateVelocity = new Vector3(0f, 0f, _targetRotation);
        }

        float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
        {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }

        public override void LateUpdate()
        {
            mTransform.position += moveVelocity * movingSpeed;

            mTransform.eulerAngles += rotateVelocity * rotationSpeed;

            moveVelocity *= movingInertia;
            rotateVelocity *= rotationInertia;
        }
    }
}
