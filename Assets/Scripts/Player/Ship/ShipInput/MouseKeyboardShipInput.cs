using UnityEngine;

namespace Assets.Scripts.Player.Ship.ShipInput
{
    public class MouseKeyboardShipInput : KeyboardShipInput
    {
        private Vector3 lastMousePos;

        protected override float CalcHorAxis()
        {
            var f = (Input.mousePosition - lastMousePos).z;

            return f;
        }


        protected override float CalcVerAxis()
        {
            if (Input.GetMouseButton(0))
            {
                return 1;
            }

            var verAxis = Input.GetAxis("Vertical");

            return verAxis;
        }

        public override void Update()
        {
            base.Update();
            if (Input.mousePosition != lastMousePos)
            {
                CallMouseMoved();
                lastMousePos = Input.mousePosition;
            }
        }
    }
}