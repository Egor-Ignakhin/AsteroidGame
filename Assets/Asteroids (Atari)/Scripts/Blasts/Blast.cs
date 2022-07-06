using System;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Blasts
{
    public class Blast : MonoBehaviour, IPoolable
    {
        public event Action<IPoolable> Realized;
        [SerializeField] private AudioSource mSource;

        private void OnEnable()
        {
            mSource.Play();
        }
    }
}
