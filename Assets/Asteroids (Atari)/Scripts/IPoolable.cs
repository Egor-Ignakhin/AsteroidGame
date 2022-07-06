using System;

namespace Asteroids__Atari_.Scripts
{
    public interface IPoolable
    {
        public event Action<IPoolable> Realized;
    }
}