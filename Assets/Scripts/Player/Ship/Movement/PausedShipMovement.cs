using UnityEngine;

namespace Assets.Scripts.Player.Ship.Movement
{
    public class PausedShipMovement : ShipMovement
    {
        public PausedShipMovement(Transform t, AudioSource audioSource) : base(t, audioSource)
        {
        }

        protected override void AccelerationKeysPressed()
        {
        }

        protected override void RotationKeysPressed()
        {
        }

        public override void LateUpdate()
        {
        }
    }
}
