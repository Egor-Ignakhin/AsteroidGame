using UnityEngine;

namespace Assets.Scripts.Player.Ship.Movement
{
    public class PausedShipMovement : ShipMovement
    {
        public PausedShipMovement(Transform t, AudioSource audioSource) : base(t, audioSource)
        {
        }

        protected override void MovingKeysPressed()
        {
        }

        protected override void RotationKeysPressed()
        {
        }

        protected override void OnMouseMoved()
        {
            throw new System.NotImplementedException();
        }

        public override void LateUpdate()
        {
        }
    }
}
