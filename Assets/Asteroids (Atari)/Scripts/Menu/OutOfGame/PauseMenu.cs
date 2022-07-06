using Asteroids__Atari_.Scripts.Player;
using Asteroids__Atari_.Scripts.Player.Ship;
using Asteroids__Atari_.Scripts.Player.Ship.ShipInput;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Asteroids__Atari_.Scripts.Menu.OutOfGame
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Ship ship;
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
            ship.SetInput(isPaused ? new PausedShipInput() : ship.GetLastInput());

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
                ship.SetLastInput(new KeyboardShipInput());
            }
            else if (inputOption == 1)
            {
                ship.SetLastInput(new MouseKeyboardShipInput());
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
