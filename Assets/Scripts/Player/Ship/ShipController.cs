using Assets.Scripts.Player.Ship.Movement;
using Assets.Scripts.Player.Ship.ShipStates;

using System;
using System.Collections;
using Assets.Scripts.Player.Ship.States;
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

        [SerializeField] private ShipStats shipStats;

        private void Awake()
        {
            mainMovement = new MainShipMovement(transform, movementSource,
                shipStats.GetMovingSpeed(),
                shipStats.GetRotationSpeed(),
                shipStats.GetMovingInertia(),
                shipStats.GetRotationInertia());
            pausedMovement = new PausedShipMovement(transform, movementSource);
            SetInput(new KeyboardShipInput());
        }

        private void Start()
        {
            shipCollider.DestroyableContacted += OnDestroyableContacted;
            shipCollider.BulletReceived += Destroy;
            StartCoroutine(nameof(ReBorning));
        }

        public void SetState(IShipState state)
        {
            currentState = state;

            StateChanged?.Invoke();
        }

        private void OnDestroyableContacted(IDestroyable obj)
        {
            if (currentState is InvulnerabilityShipState)
                return;

            obj.Destroy();

            Destroy();
        }

        private IEnumerator ReBorning()
        {
            SetState(new InvulnerabilityShipState());

            yield return new WaitForSeconds(3);

            SetState(new MainShipState());
        }

        private void Update()
        {
            shipInput?.Update();
        }

        private void LateUpdate()
        {
            currentMovement.LateUpdate();
        }

        public void Destroy()
        {
            Destroyed?.Invoke(this);

            BlastBuilder.Build(transform.position);

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

        public void SetLastInput(IShipInput input)
        {
            lastInput = input;
        }
        public IShipInput GetLastInput()
        {
            return lastInput;
        }

        private void OnDisable()
        {
            shipCollider.DestroyableContacted -= OnDestroyableContacted;
            shipCollider.BulletReceived -= Destroy;
        }
    }
}
