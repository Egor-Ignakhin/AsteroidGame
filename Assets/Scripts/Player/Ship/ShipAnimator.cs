using UnityEngine;

namespace Assets.Scripts.Player.Ship
{
    public class ShipAnimator : MonoBehaviour
    {
        [SerializeField] private ShipController shipController;

        private void Awake()
        {
            shipController.Destroyed += OnShipDestroyed;
        }

        private void Start()
        {
            OnShipDestroyed(null);
        }

        private void OnShipDestroyed(IDestroyable obj)
        {
            transform.position = new Vector3(Screen.width / 2f, Screen.height / 2f);
        }

        private void OnDestroy()
        {
            shipController.Destroyed -= OnShipDestroyed;
        }
    }
}
