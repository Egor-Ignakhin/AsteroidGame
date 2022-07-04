using UnityEngine;

namespace Assets.Scripts.Player.Ship
{
    [CreateAssetMenu(fileName = "ShipStats", menuName = "ScriptableObjects/ShipStats", order = 1)]
    public class ShipStats : ScriptableObject
    {
        [SerializeField] private float movingSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField, Range(0, 1)] private float movingInertia;
        [SerializeField, Range(0, 1)] private float rotationInertia;

        public float GetMovingSpeed()
        {
            return movingSpeed;
        }

        public float GetRotationSpeed()
        {
            return rotationSpeed;
        }

        public float GetMovingInertia()
        {
            return movingInertia;
        }
        public float GetRotationInertia()
        {
            return rotationInertia;
        }
    }
}
