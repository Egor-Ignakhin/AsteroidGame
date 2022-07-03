using System;
using Assets.Scripts.Player.Ship;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public event Action Changed;

        [SerializeField] private GameObject shipDestroyableGM;
        private  IDestroyable shipDestroyable;
        private int health = 5;

        public int GetHealth()
        {
            return health;
        }

        private void Awake()
        {
            shipDestroyable = shipDestroyableGM.GetComponent<IDestroyable>();
            shipDestroyable.Destroyed += Kill;
        }

        public void Kill(IDestroyable _)
        {
            health--;
            Changed?.Invoke();

            if (health == 0)
            {
                SceneManager.LoadScene(0);
            }
        }

        private void OnDestroy()
        {
            shipDestroyable.Destroyed -= Kill;
        }
    }
}
