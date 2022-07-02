using UnityEngine;

namespace Assets.Scripts.Player.Ship
{
    public class ShipCombat : MonoBehaviour
    {
        private IShipInput shipInput;
        private BulletsPool bulletsPool;
        [SerializeField] private Transform bulletsParent;
        [SerializeField] private Transform bulletsInstantiatePlace;

        private void Awake()
        {
            bulletsPool = new BulletsPool(bulletsParent, 15);
        }

        public void SetShipInput(IShipInput shipInput)
        {
            if (this.shipInput != null)
            {
                this.shipInput.ShootKeyDown -= OnShootKeyDown;
            }

            this.shipInput = shipInput;
            this.shipInput.ShootKeyDown += OnShootKeyDown;
        }

        private void OnShootKeyDown()
        {
            var bullet = bulletsPool.GetObjectFromPool();

            bullet.transform.position = bulletsInstantiatePlace.position;
            bullet.Initialize(transform.right);
        }
    }
}
