using UnityEngine;

namespace Assets.Scripts.Player.Ship
{
    public class MouseKeyboardShipInput : KeyboardShipInput
    {
        private Vector3 lastMousePos;

        protected override float CalcHorAxis()
        {
            var f = (Input.mousePosition - lastMousePos).z;

            lastMousePos = Input.mousePosition;

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
            }
        }
    }
}