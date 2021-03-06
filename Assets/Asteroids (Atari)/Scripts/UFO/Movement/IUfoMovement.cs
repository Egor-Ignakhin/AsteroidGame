using System;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.UFO.Movement
{
    internal interface IUfoMovement
    {
        public event Action MovementIsOver;
        void Move();

        void Initialize(Vector3 startPosition, Vector3 targetPosition);
    }
}