using System;
using UnityEngine;

namespace Assets.Scripts.Player.Ship.Movement
{
    [Serializable]
    public abstract class ShipMovement
    {
        protected IShipInput shipInput;
        protected float moveMomentum = 0;
        protected float rotateMomentum = 0;
        protected Vector3 lastMoveDirection;
        protected Vector3 lastRotateDirection;
        protected Transform mTransform;
        [SerializeField] protected AudioSource audioSource;

        public ShipMovement(Transform t, AudioSource audioSource)
        {
            mTransform = t;
            this.audioSource = audioSource;
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

        protected abstract void AccelerationKeysPressed();

        protected abstract void RotationKeysPressed();

        public abstract void LateUpdate();

        protected Vector3 CalcRotateMomentum()
        {
            float rotateSmoothing = rotateMomentum / 10;
            return lastRotateDirection *= rotateSmoothing;
        }

        protected Vector3 CalcMoveMomentum()
        {
            float moveSmoothing = moveMomentum / 10;
            return lastMoveDirection *= moveSmoothing;
        }
    }
}
