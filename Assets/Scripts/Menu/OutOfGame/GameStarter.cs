using Assets.Scripts.Player.Ship;
using Assets.Scripts.Player.Ship.ShipStates;

using System;

using UnityEngine;

namespace Assets.Scripts
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameObject playerGameObject;
        [SerializeField] private GameObject ui;
        private static bool gameIsStarted;

        private void OnEnable()
        {
            gameIsStarted = false;
            playerGameObject.SetActive(false);
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Return)) return;
            if (gameIsStarted) return;

            playerGameObject.SetActive(true);
            ui.SetActive(false);
            gameIsStarted = true;
        }

        internal static bool GameIsStarted()
        {
            return gameIsStarted;
        }
    }
}
