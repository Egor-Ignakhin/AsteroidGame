using System;
using System.Collections.Generic;
using Asteroids__Atari_.Scripts.Asteroids;
using Asteroids__Atari_.Scripts.Bullets;
using Asteroids__Atari_.Scripts.Player.Ship;
using Asteroids__Atari_.Scripts.UFO;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Balance
{
    [CreateAssetMenu(fileName = "RewardBalance", menuName = "ScriptableObjects/RewardBalance", order = 1)]
    public class RewardBalance : ScriptableObject
    {
        [SerializeField] private int bigAsteroidDestroy;
        [SerializeField] private int mediumAsteroidDestroy;
        [SerializeField] private int smallAsteroidDestroy;
        [SerializeField] private int UFODestroy;

        private Dictionary<Type, int> rewardsMap;

        public int CalcScores(IBulletReceiver bulletReceiver)
        {
            return rewardsMap[bulletReceiver.GetType()];
        }

        private void OnValidate()
        {
            rewardsMap = new Dictionary<Type, int>()
            {
                { typeof(BigAsteroid), bigAsteroidDestroy },
                { typeof(MediumAsteroid), mediumAsteroidDestroy },
                { typeof(SmallAsteroid), smallAsteroidDestroy },
                { typeof(UfoCollider), UFODestroy },
                { typeof(ShipCollider), 0 },
            };
        }
    }
}
