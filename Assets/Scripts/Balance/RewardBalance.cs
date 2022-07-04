using System;
using System.Collections.Generic;
using Assets.Scripts.Asteroids;
using Assets.Scripts.Bullets;
using Assets.Scripts.Player.Ship;
using Assets.Scripts.UFO;
using UnityEngine;

namespace Assets.Scripts.Balance
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
