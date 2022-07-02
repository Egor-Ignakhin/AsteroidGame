using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerStats : MonoBehaviour
    {
        public event Action Changed;

        private int health = 5;
        private int scores;

        private void Start()
        {
            Changed?.Invoke();
        }

        public int GetHealth()
        {
            return health;
        }

        public int GetScores()
        {
            return scores;
        }
    }
}
