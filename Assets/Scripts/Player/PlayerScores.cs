using System;
using Assets.Scripts.Balance;
using Assets.Scripts.Player.Ship;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Player
{
    public class PlayerScores : MonoBehaviour
    {
        public event Action Changed;
        [SerializeField] private ScoresBalance scoresBalance;

        [SerializeField] private ShipCombat shipCombat;
        private int scores = 0;

        public int GetScores()
        {
            return scores;
        }

        private void Awake()
        {
            shipCombat.BulletHited += OnBulletHited;
        }

        public void OnBulletHited(IBulletReceiver bulletReceiver)
        {
            scores += scoresBalance.CalcScores(bulletReceiver);

            Changed?.Invoke();
        }

        private void OnDestroy()
        {
            shipCombat.BulletHited -= OnBulletHited;
        }
    }
}
