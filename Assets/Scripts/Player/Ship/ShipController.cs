using Assets.Scripts.Player.Ship.Movement;
using Assets.Scripts.Player.Ship.ShipStates;

using System;
using System.Collections;

using UnityEngine;

namespace Assets.Scripts.Player.Ship
{
    public class ShipController : MonoBehaviour, IDestroyable
    {
        public event Action StateChanged;
        public event Action<IDestroyable> Destroyed;
        private IShipInput shipInput;

        [SerializeField] private AudioSource movementSource;
        
        private ShipMovement currentMovement;
        private ShipMovement pausedMovement;
        private ShipMovement mainMovement;
        
        [SerializeField] private ShipCombat shipCombat;
        [SerializeField] private ShipCollider shipCollider;

        private IShipState currentState;
        private IShipInput lastInput;

        private void Awake()
        {
            mainMovement = new MainShipMovement(transform, movementSource);
            pausedMovement = new PausedShipMovement(transform, movementSource);
            SetInput(new KeyboardShipInput());
            shipCollider.DestroyableContacted += OnDestroyableContacted;
            shipCollider.BulletReceived += FullDestroy;
        }

        private void Start()
        {
            SetState(new InvulnerabilityShipState());
        }

        private void SetState(IShipState state)
        {
            currentState = state;

            StateChanged?.Invoke();
        }

        private void OnDestroyableContacted(IDestroyable obj)
        {
            obj.FullDestroy();

            FullDestroy();
        }

        private IEnumerator ReBorning()
        {
            SetState(new InvulnerabilityShipState());

            yield return new WaitForSeconds(3);
        }

        private void Update()
        {
            shipInput?.Update();
        }

        private void LateUpdate()
        {
            currentMovement.LateUpdate();
        }

        public void FullDestroy()
        {
            Destroyed?.Invoke(this);

            BlastsManager.Blast(transform.position);

            StartCoroutine(nameof(ReBorning));
        }

        public IShipState GetState()
        {
            return currentState;
        }

        public void SetInput(IShipInput input)
        {
            lastInput = shipInput;

            shipInput = input;

            if (input is PausedShipInput)
            {
                currentMovement = pausedMovement;
            }
            else
            {
                currentMovement = mainMovement;
            }

            currentMovement.SetShipInput(shipInput);
            shipCombat.SetShipInput(shipInput);
        }

        public IShipInput GetLastInput()
        {
            return lastInput;
        }

        private void OnDestroy()
        {
            shipCollider.DestroyableContacted -= OnDestroyableContacted;
            shipCollider.BulletReceived -= FullDestroy;
        }
    }
}
