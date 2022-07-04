using Assets.Scripts.Player;
using Assets.Scripts.Player.Ship;

using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.OutOfGame
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private ShipController shipController;
        [SerializeField] private GameObject panel;
        [SerializeField] private TMP_Dropdown shipInputDropdown;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button exitButton;

        private void Awake()
        {
            playerInput.Paused += OnPaused;
            continueButton.onClick.AddListener(ContinueGame);
            newGameButton.onClick.AddListener(PlayNewGame);
            shipInputDropdown.onValueChanged.AddListener(ChangedShipInput);
            exitButton.onClick.AddListener(ExitFromGame);
        }

        private void OnPaused()
        {
            bool isPaused = playerInput.IsPaused();
            panel.SetActive(isPaused);
            shipController.SetInput(isPaused ? new PausedShipInput() : shipController.GetLastInput());

            continueButton.interactable = GameStarter.GameIsStarted();
        }

        private void ContinueGame()
        {
            playerInput.SetPaused(false);
        }

        private void PlayNewGame()
        {
            SceneManager.LoadScene(0);
        }

        private void ExitFromGame()
        {
            Application.Quit();
        }

        private void ChangedShipInput(int inputOption)
        {
            if (inputOption == 0)
            {
                shipController.SetLastInput(new KeyboardShipInput());
            }
            else if (inputOption == 1)
            {
                shipController.SetLastInput(new MouseKeyboardShipInput());
            }
        }

        private void OnDestroy()
        {
            playerInput.Paused -= OnPaused;
            continueButton.onClick.RemoveListener(ContinueGame);
            newGameButton.onClick.RemoveListener(PlayNewGame);
            shipInputDropdown.onValueChanged.RemoveListener(ChangedShipInput);
            exitButton.onClick.RemoveListener(ExitFromGame);
        }
    }
}
