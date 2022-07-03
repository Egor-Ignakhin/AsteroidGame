using UnityEngine;

namespace Assets.Scripts.Player.Ship.Movement
{
    public class MainShipMovement : ShipMovement
    {
        public MainShipMovement(Transform t, AudioSource audioSource) : base(t, audioSource)
        {
        }

        protected override void AccelerationKeysPressed()
        {
            lastMoveDirection = mTransform.right * shipInput.GetMoveSign();
            mTransform.position += lastMoveDirection;
            moveMomentum = 10;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        protected override void RotationKeysPressed()
        {
            var speed = 2;
            var startRot = mTransform.eulerAngles;
            mTransform.eulerAngles += shipInput.GetRotationDirection() * speed;
            lastRotateDirection = mTransform.eulerAngles - startRot;
            rotateMomentum = 10;
        }

        public override void LateUpdate()
        {
            mTransform.position += CalcMoveMomentum();

            mTransform.eulerAngles += CalcRotateMomentum();

            moveMomentum -= Time.deltaTime / 10;
            rotateMomentum -= Time.deltaTime / 10;
        }
    }
}
