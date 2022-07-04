using Assets.Scripts.Balance;
using Assets.Scripts.Player.Ship;

using System;
using Assets.Scripts.Bullets;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerScores : MonoBehaviour
    {
        public event Action Changed;
        [SerializeField] private RewardBalance rewardBalance;
        [SerializeField] private ShipsCannon shipsCannon;

        private int scores;

        public int GetScores()
        {
            return scores;
        }

        private void Awake()
        {
            shipsCannon.BulletHit += OnBulletHit;
        }

        public void OnBulletHit(IBulletReceiver bulletReceiver)
        {
            scores += rewardBalance.CalcScores(bulletReceiver);

            Changed?.Invoke();
        }

        private void OnDestroy()
        {
            shipsCannon.BulletHit -= OnBulletHit;
        }
    }
}
