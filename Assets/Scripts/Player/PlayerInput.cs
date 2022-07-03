using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action Paused;
        private bool isPaused = false;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                Paused?.Invoke();
            }
        }

        public bool IsPaused()
        {
            return isPaused;
        }

        private void OnDestroy()
        {
            Paused = null;
        }
    }
}
