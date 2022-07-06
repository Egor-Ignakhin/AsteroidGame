using Asteroids__Atari_.Scripts.Player.Ship.ShipInput;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Player.Ship.Movement
{
    public abstract class ShipMovement
    {
        protected IShipInput shipInput;
        protected Vector3 moveVelocity;
        protected Vector3 rotateVelocity;
        protected Transform mTransform;
        [SerializeField] protected AudioSource audioSource;

        protected ShipMovement(Transform t, AudioSource audioSource)
        {
            mTransform = t;
            this.audioSource = audioSource;
        }

        internal void SetShipInput(IShipInput shipInput)
        {
            if (this.shipInput != null)
            {
                this.shipInput.MovingKeysPressed -= MovingKeysPressed;
                this.shipInput.RotationKeysPressed -= RotationKeysPressed;
                this.shipInput.MouseMoved -= OnMouseMoved;
            }

            this.shipInput = shipInput;

            this.shipInput.MovingKeysPressed += MovingKeysPressed;
            this.shipInput.RotationKeysPressed += RotationKeysPressed;
            this.shipInput.MouseMoved += OnMouseMoved;
        }

        protected abstract void MovingKeysPressed();

        protected abstract void RotationKeysPressed();

        protected abstract void OnMouseMoved();

        public abstract void FixedUpdate();
    }
}
