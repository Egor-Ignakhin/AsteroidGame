using Assets.Scripts.Player;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Menu.InGame
{
    public class PlayerStatsView : MonoBehaviour
    {
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private TextMeshProUGUI playerHealthText;
        [SerializeField] private TextMeshProUGUI playerScoresText;

        private void Awake()
        {
            playerStats.Changed += OnStatsChanged;
        }

        private void OnStatsChanged()
        {
            playerHealthText.SetText($"Health: {playerStats.GetHealth()}");
            playerScoresText.SetText($"Scores: {playerStats.GetScores()}");
        }

        private void OnDestroy()
        {
            playerStats.Changed -= OnStatsChanged;
        }
    }
}
