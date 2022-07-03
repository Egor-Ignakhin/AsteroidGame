using System;

using UnityEngine;

namespace Assets.Scripts
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
