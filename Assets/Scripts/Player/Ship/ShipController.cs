using System;

using UnityEngine;

namespace Assets.Scripts.Player.Ship
{
    public class ShipController : MonoBehaviour, IDestroyable
    {
        public event Action<IDestroyable> Destroyed;
        private IShipInput shipInput;
        [SerializeField] private PlayerInput playerInput;

        [SerializeField] private ShipMovement shipMovement;
        [SerializeField] private ShipCombat shipCombat;
        [SerializeField] private ShipCollider shipCollider;

        private void Awake()
        {
            playerInput.Paused += OnPaused;
            shipInput = new KeyboardShipInput();
            shipMovement.SetShipInput(shipInput);
            shipCombat.SetShipInput(shipInput);
            shipCollider.DestroyableContacted += OnDestroyableContacted;
            shipCollider.BulletReceived += FullDestroy;
        }

        private void OnPaused()
        {
            throw new System.NotImplementedException();
        }


        private void OnDestroyableContacted(IDestroyable obj)
        {
            obj.FullDestroy();

            FullDestroy();

            BlastsManager.Blast(transform.position);
        }

        private void Update()
        {
            shipInput.Update();
        }

        private void OnDestroy()
        {
            playerInput.Paused -= OnPaused;
            shipCollider.DestroyableContacted -= OnDestroyableContacted;
            shipCollider.BulletReceived -= FullDestroy;
        }

        public void FullDestroy()
        {
            Destroyed?.Invoke(this);
        }
    }
}
