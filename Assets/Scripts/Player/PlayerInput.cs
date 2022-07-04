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
                SetPaused(!isPaused);
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

        public void SetPaused(bool b)
        {
            isPaused = b;
            Paused?.Invoke();
        }
    }
}
