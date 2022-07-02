using System;
using UnityEngine;

namespace Assets.Scripts.Asteroids
{
    public interface IBaseAsteroid : IBulletReceiver, IPoolable
    {
        public event Action Destroyed;
    }
}
