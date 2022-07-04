
using UnityEngine;

namespace Assets.Scripts.Player
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats", order = 1)]
    public class PlayerStats : ScriptableObject
    {
        [SerializeField] private int startPlayerHealth;
        [SerializeField] private int minPlayerHealth;

        public int GetStartPlayerHealth()
        {
            return startPlayerHealth;
        }

        public int GetMinPlayerHealth()
        {
            return minPlayerHealth;
        }
    }
}
