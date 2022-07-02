using System;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IPoolable
    {
        public event Action<IPoolable> Realized;
    }
}