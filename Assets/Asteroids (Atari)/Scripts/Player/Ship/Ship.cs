using System;
using System.Collections;
using Asteroids__Atari_.Scripts.Blasts;
using Asteroids__Atari_.Scripts.Player.Ship.Cannon;
using Asteroids__Atari_.Scripts.Player.Ship.Movement;
using Asteroids__Atari_.Scripts.Player.Ship.ShipInput;
using Asteroids__Atari_.Scripts.Player.Ship.States;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Player.Ship
{
    public class Ship : MonoBehaviour, IDestroyable
    {
        public event Action StateChanged;
        public event Action<IDestroyable> Destroyed;
        private IShipInput shipInput;

        [SerializeField] private AudioSource movementSource;

        private ShipMovement currentMovement;
        private ShipMovement pausedMovement;
        private ShipMovement mainMovement;

        [SerializeField] private ShipsCannon cannon;
        [SerializeField] private ShipCollider mCollider;

        private IShipState currentState;
        private IShipInput lastInput;

        [SerializeField] private ShipStats stats;

        private void Awake()
        {
            mainMovement = new MainShipMovement(
                transform,
                movementSource,
                stats.GetMovementSpeed(),
                stats.GetRotationalSpeed(),
                stats.GetMovementInertia(),
                stats.GetRotationalInertia());
            pausedMovement = new PausedShipMovement(transform, movementSource);
            SetInput(new KeyboardShipInput());
        }

        private void Start()
        {
            mCollider.DestroyableContacted += OnDestroyableContacted;
            mCollider.BulletReceived += Destroy;
            StartCoroutine(nameof(Rebirth));
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

        private IEnumerator Rebirth()
        {
            SetState(new InvulnerabilityShipState());

            yield return new WaitForSeconds(3);

            SetState(new MainShipState());
        }

        private void FixedUpdate()
        {
            currentMovement.FixedUpdate();
        }

        private void Update()
        {
            shipInput?.Update();
        }

        public void Destroy()
        {
            Destroyed?.Invoke(this);

            BlastBuilder.Build(transform.position);

            StartCoroutine(nameof(Rebirth));
        }

        public IShipState GetState()
        {
            return currentState;
        }

        public void SetInput(IShipInput input)
        {
            lastInput = shipInput;

            shipInput = input;

            currentMovement = input is PausedShipInput ? pausedMovement : mainMovement;

            currentMovement.SetShipInput(shipInput);
            cannon.SetShipInput(shipInput);
        }

        public IShipInput GetLastInput()
        {
            return lastInput;
        }

        public void SetLastInput(IShipInput input)
        {
            lastInput = input;
        }

        private void OnDisable()
        {
            mCollider.DestroyableContacted -= OnDestroyableContacted;
            mCollider.BulletReceived -= Destroy;
        }
    }
}
