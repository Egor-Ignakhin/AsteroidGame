using UnityEngine;

namespace Assets.Scripts.Player.Ship
{
    public class ShipMovement : MonoBehaviour
    {
        private IShipInput shipInput;
        private float moveMomentum = 0;
        private float rotateMomentum = 0;
        private Vector3 lastMoveDirection;
        private Vector3 lastRotateDirection;
        [SerializeField] private AudioSource audioSource;

        private void SetPaused()
        {
            throw new System.NotImplementedException();
        }

        internal void SetShipInput(IShipInput shipInput)
        {
            if (this.shipInput != null)
            {
                this.shipInput.AccelerationKeysPressed -= AccelerationKeysPressed;
                this.shipInput.RotationKeysPressed -= RotationKeysPressed;
            }

            this.shipInput = shipInput;

            this.shipInput.AccelerationKeysPressed += AccelerationKeysPressed;
            this.shipInput.RotationKeysPressed += RotationKeysPressed;
        }

        private void AccelerationKeysPressed()
        {
            lastMoveDirection = transform.right * shipInput.GetMoveSign();
            transform.position += lastMoveDirection;
            moveMomentum = 10;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }

        private void RotationKeysPressed()
        {
            var speed = 2;
            var startRot = transform.eulerAngles;
            transform.eulerAngles += shipInput.GetRotationDirection() * speed;
            lastRotateDirection = transform.eulerAngles - startRot;
            rotateMomentum = 10;
        }

        private void LateUpdate()
        {
            transform.position += CalcMoveMomentum();

            transform.eulerAngles += CalcRotateMomentum();

            moveMomentum -= Time.deltaTime / 10;
            rotateMomentum -= Time.deltaTime / 10;
        }

        private Vector3 CalcRotateMomentum()
        {
            float rotateSmoothing = rotateMomentum / 10;
            return lastRotateDirection *= rotateSmoothing;
        }

        private Vector3 CalcMoveMomentum()
        {
            float moveSmoothing = moveMomentum / 10;
            return lastMoveDirection *= moveSmoothing;
        }
    }
}
