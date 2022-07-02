using UnityEngine;

namespace Assets.Scripts.Player.Ship
{
    public class ShipController : MonoBehaviour
    {
        private IShipInput shipInput;
        [SerializeField] private PlayerInput playerInput;

        [SerializeField] private ShipMovement shipMovement;
        [SerializeField] private ShipCombat shipCombat;

        private void Awake()
        {
            playerInput.Paused += OnPaused;
            shipInput = new KeyboardShipInput();
            shipMovement.SetShipInput(shipInput);
            shipCombat.SetShipInput(shipInput);
        }

        private void OnPaused()
        {
            throw new System.NotImplementedException();
        }

        private void Update()
        {
            shipInput.Update();
        }

        private void OnDestroy()
        {
            playerInput.Paused -= OnPaused;
        }
    }
}
