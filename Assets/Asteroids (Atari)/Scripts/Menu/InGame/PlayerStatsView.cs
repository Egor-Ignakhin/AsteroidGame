using Asteroids__Atari_.Scripts.Player;
using TMPro;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Menu.InGame
{
    public class PlayerStatsView : MonoBehaviour
    {
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private PlayerScores playerScores;

        [SerializeField] private TextMeshProUGUI playerHealthText;
        [SerializeField] private TextMeshProUGUI playerScoresText;

        private void Awake()
        {
            playerHealth.Changed += OnStatsChanged;
            playerScores.Changed += OnStatsChanged;
        }

        private void OnStatsChanged()
        {
            playerHealthText.SetText($"Health: {playerHealth.GetHealth()}");
            playerScoresText.SetText($"Scores: {playerScores.GetScores()}");
        }

        private void OnDestroy()
        {
            playerHealth.Changed -= OnStatsChanged;
            playerScores.Changed -= OnStatsChanged;
        }
    }
}
