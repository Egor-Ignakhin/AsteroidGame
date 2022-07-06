using UnityEngine;

namespace AnimationsIntegration.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        private Vector3 positionDifference;
        private Vector3 lastPosition;

        public Vector3 GetPositionDifference()
        {
            return positionDifference;
        }

        private void Awake()
        {
            playerInput.MovementKeysPressed += PlayerInput_movementKeysPressed;
        }

        private void PlayerInput_movementKeysPressed()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            transform.position += transform.forward * v * Time.deltaTime * 5;
            transform.eulerAngles += new Vector3(0, h, 0) * Time.deltaTime * 100;
        }

        private void Update()
        {
            positionDifference = transform.position - lastPosition;

            lastPosition = transform.position;
        }

        private void OnDestroy()
        {
            playerInput.MovementKeysPressed -= PlayerInput_movementKeysPressed;
        }
    }
}
