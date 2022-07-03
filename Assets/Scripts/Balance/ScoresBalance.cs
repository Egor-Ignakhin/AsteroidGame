using System;
using System.Collections.Generic;
using Assets.Scripts.Asteroids;
using Assets.Scripts.Player.Ship;
using Assets.Scripts.UFO;
using UnityEngine;

namespace Assets.Scripts.Balance
{
    [CreateAssetMenu(fileName = "ScoresBalance", menuName = "ScriptableObjects/ScoresBalance", order = 1)]
    public class ScoresBalance : ScriptableObject
    {
        [SerializeField] private int bigAsteroidDestroyReward;
        [SerializeField] private int mediumAsteroidDestroyReward;
        [SerializeField] private int smallAsteroidDestroyReward;
        [SerializeField] private int UFODestroyReward;

        private Dictionary<Type, int> rewardsMap;

        public int CalcScores(IBulletReceiver bulletReceiver)
        {
            return rewardsMap[bulletReceiver.GetType()];
        }

        private void OnValidate()
        {
            rewardsMap = new Dictionary<Type, int>()
            {
                { typeof(BigAsteroid), bigAsteroidDestroyReward },
                { typeof(MediumAsteroid), mediumAsteroidDestroyReward },
                { typeof(SmallAsteroid), smallAsteroidDestroyReward },
                { typeof(UFOCollider), UFODestroyReward },
                { typeof(ShipCollider), 0 },
            };
        }
    }
}
