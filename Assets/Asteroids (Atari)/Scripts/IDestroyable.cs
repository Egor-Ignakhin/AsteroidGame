using System;

namespace Asteroids__Atari_.Scripts
{
    public interface IDestroyable
    {
        event Action<IDestroyable> Destroyed;

        void Destroy();
    }
}