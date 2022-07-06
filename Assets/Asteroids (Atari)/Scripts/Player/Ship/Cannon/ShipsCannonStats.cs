using UnityEngine;

namespace Asteroids__Atari_.Scripts.Player.Ship.Cannon
{
    [CreateAssetMenu(fileName = "ShipsCannonStats", menuName = "ScriptableObjects/ShipsCannonStats", order = 1)]
    public class ShipsCannonStats : ScriptableObject
    {
        [SerializeField] private int maxShootsPerSecond = 3;

        public int GetMaxShootsPerSecond()
        {
            return maxShootsPerSecond;
        }
    }
}
