using Assets.Scripts.Player;
using Assets.Scripts.Player.Ship;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Menu.OutOfGame
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private ShipController shipController;
        [SerializeField] private GameObject panel;
        [SerializeField] private TMP_Dropdown shipInputDropdown;

        private void Awake()
        {
            playerInput.Paused += OnPaused;
            shipInputDropdown.onValueChanged.AddListener(ChangedShipInput);
        }

        private void OnPaused()
        {
            bool isPaused = playerInput.IsPaused();
            panel.SetActive(isPaused);
            shipController.SetInput(isPaused? new PausedShipInput() : shipController.GetLastInput());
        }

        private void ChangedShipInput(int inputOption)
        {
            if (inputOption == 0)
            {
                shipController.SetInput(new KeyboardShipInput());
            }
            else if (inputOption == 1)
            {
                shipController.SetInput(new MouseKeyboardShipInput());
            }
        }

        private void OnDestroy()
        {
            playerInput.Paused -= OnPaused;
            shipInputDropdown.onValueChanged.RemoveListener(ChangedShipInput);
        }
    }
}
