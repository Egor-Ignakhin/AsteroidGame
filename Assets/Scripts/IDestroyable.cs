using System;

namespace Assets.Scripts
{
    public interface IDestroyable
    {
        event Action<IDestroyable> Destroyed;
        void FullDestroy();
    }
}