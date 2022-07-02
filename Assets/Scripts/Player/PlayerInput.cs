using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action Paused;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Paused?.Invoke();
            }
        }

    }
}
