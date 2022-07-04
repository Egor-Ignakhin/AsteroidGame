using System;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public event Action Changed;

        [SerializeField] private GameObject shipDestroyableGM;
        private IDestroyable shipDestroyable;

        [SerializeField] private PlayerStats playerStats;

        private int health;

        public int GetHealth()
        {
            return health;
        }

        private void Awake()
        {
            health = playerStats.GetStartPlayerHealth();
            shipDestroyable = shipDestroyableGM.GetComponent<IDestroyable>();
            shipDestroyable.Destroyed += Kill;
        }

        public void Kill(IDestroyable _)
        {
            health--;
            Changed?.Invoke();

            if (health == playerStats.GetMinPlayerHealth())
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
