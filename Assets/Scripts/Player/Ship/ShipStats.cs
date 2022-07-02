using UnityEngine;

namespace Assets.Scripts.Player.Ship
{
    public class ShipStats : MonoBehaviour
    {
        [SerializeField] private int maxSpeed;
        [SerializeField] private int rotationSpeed;
        [SerializeField] private int acceleration;
        [SerializeField] private int momentum;
    }
}
