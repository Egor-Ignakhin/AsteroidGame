using System;
using UnityEngine;

namespace Assets.Scripts.UFO.Movement
{
    public class PausedUfoMovement : IUfoMovement
    {
        public event Action MovementIsOver;

        public void Move()
        {
        }

        public void Initialize(Vector3 startPosition, Vector3 targetPosition)
        {
        }
    }
}