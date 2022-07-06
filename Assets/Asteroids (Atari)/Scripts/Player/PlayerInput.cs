using System;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action Paused;
        private bool isPaused = false;
        [SerializeField] private KeyCode pauseKeyCode = KeyCode.Escape;

        private void Update()
        {
            if (Input.GetKeyDown(pauseKeyCode))
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
