using UnityEngine;

namespace Assets.Scripts.Player.Ship
{
    public class ShipMovement : MonoBehaviour
    {
        private IShipInput shipInput;

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
            transform.position += transform.right * shipInput.GetMoveSign();
        }

        private void RotationKeysPressed()
        {
            transform.Rotate(shipInput.GetRotationDirection());
        }
    }
}
