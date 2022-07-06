using System.Threading.Tasks;
using UnityEngine;

namespace AnimationsIntegration.Scripts.Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;
        [SerializeField] private GameObject uiHing;
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject sword;
        [SerializeField] private GameObject gun;

        private void Update()
        {
            if (enemy.IsAlive() && (Vector3.Distance(transform.position, enemy.transform.position) < 3))
            {
                uiHing.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    enemy.Kill();
                    animator.SetBool("IsFinishing", true);
                    gun.SetActive(false);

                    sword.SetActive(true);

                    transform.position = enemy.transform.position + enemy.transform.forward * 1.5f;
                    transform.LookAt(enemy.transform);
                }
            }
            else
            {
                uiHing.SetActive(false);
            }
        }

        public void OnEnemyFinished()
        {
            animator.SetBool("IsFinishing", false);
            sword.SetActive(false);
            gun.SetActive(true);
        }
    }
}
