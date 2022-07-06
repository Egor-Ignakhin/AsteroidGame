using System;
using Asteroids__Atari_.Scripts.Balance;
using Asteroids__Atari_.Scripts.Bullets;
using Asteroids__Atari_.Scripts.Player.Ship;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Player
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
