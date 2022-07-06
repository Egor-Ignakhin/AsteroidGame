using UnityEngine;

namespace Asteroids__Atari_.Scripts.Menu.OutOfGame
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameObject playerGameObject;
        [SerializeField] private GameObject ufoCreatorGameObject;
        [SerializeField] private GameObject ui;
        private static bool gameIsStarted;

        private void OnEnable()
        {
            gameIsStarted = false;
            playerGameObject.SetActive(false);
            ufoCreatorGameObject.SetActive(false);
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Return)) return;
            if (gameIsStarted) return;

            playerGameObject.SetActive(true);
            ufoCreatorGameObject.SetActive(true);
            ui.SetActive(false);
            gameIsStarted = true;
        }

        internal static bool GameIsStarted()
        {
            return gameIsStarted;
        }
    }
}
