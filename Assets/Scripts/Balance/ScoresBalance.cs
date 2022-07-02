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
    }
}
