using System;

using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerStats : MonoBehaviour
    {
        public event Action Changed;

        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private PlayerScores playerScores;

        private void Awake()
        {
            playerHealth.Changed += OnPlayerChanged;
            playerScores.Changed += OnPlayerChanged;
        }

        private void OnPlayerChanged()
        {
            Changed?.Invoke();
        }

        private void Start()
        {
            Changed?.Invoke();
        }

        public int GetHealth()
        {
            return playerHealth.GetHealth();
        }

        public int GetScores()
        {
            return playerScores.GetScores();
        }

        private void OnDestroy()
        {
            playerHealth.Changed -= OnPlayerChanged;
            playerScores.Changed -= OnPlayerChanged;
        }
    }
}
