using UnityEngine;

namespace Asteroids__Atari_.Scripts.Player.Ship
{
    [CreateAssetMenu(fileName = "ShipStats", menuName = "ScriptableObjects/ShipStats", order = 1)]
    public class ShipStats : ScriptableObject
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotationalSpeed;
        [SerializeField, Range(0, 1)] private float movementInertia;
        [SerializeField, Range(0, 1)] private float rotationalInertia;

        public float GetMovementSpeed()
        {
            return movementSpeed;
        }

        public float GetRotationalSpeed()
        {
            return rotationalSpeed;
        }

        public float GetMovementInertia()
        {
            return movementInertia;
        }
        public float GetRotationalInertia()
        {
            return rotationalInertia;
        }
    }
}
