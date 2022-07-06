using UnityEngine;

namespace Asteroids__Atari_.Scripts.Player.Ship.Movement
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
            moveVelocity = mTransform.right * shipInput.GetMoveSign() * 100;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        protected override void RotationKeysPressed()
        {
            rotateVelocity = mTransform.forward * shipInput.GetRotationSign() * 100;
        }

        protected override void OnMouseMoved()
        {
            var direction = Input.mousePosition - mTransform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            mTransform.rotation = Quaternion.Euler(0, 0, angle);
        }

       
        public override void FixedUpdate()
        {
            mTransform.position += moveVelocity * movingSpeed * Time.fixedDeltaTime;

            mTransform.eulerAngles += rotateVelocity * rotationSpeed * Time.fixedDeltaTime;

            moveVelocity *= movingInertia;
            rotateVelocity *= rotationInertia;
        }
    }
}
