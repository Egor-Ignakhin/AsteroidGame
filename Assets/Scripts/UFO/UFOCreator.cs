using Assets.Scripts.Player;

using System.Collections;

using UnityEngine;

namespace Assets.Scripts.UFO
{
    public class UFOCreator : MonoBehaviour
    {
        private UFOController ufoController;
        [SerializeField] private Transform playerShipTransform;
        [SerializeField] private PlayerInput playerInput;

        private void Awake()
        {
            ufoController = Instantiate(Resources.Load<UFOController>("UFO"), transform);
            ufoController.gameObject.SetActive(false);
            ufoController.Setup(transform, playerShipTransform, playerInput);
        }

        private void Start()
        {
            StartCoroutine(nameof(CreateUFO));
        }

        private IEnumerator CreateUFO()
        {
            yield return new WaitForSeconds(Random.Range(20, 40));

            ufoController.gameObject.SetActive(true);
            (Vector3 position, Vector3 target) = CalcPosAndTarget();

            ufoController.Initialize(position, target);

            ufoController.Realized += OnUFORealized;
        }

        private (Vector3, Vector3) CalcPosAndTarget()
        {
            (float xStart, float xTarget) = (0, 0);

            if (Random.Range(-1f, 1f) > 0)
            {
                (xStart, xTarget) = (Screen.width, 0);
            }
            else
            {
                (xStart, xTarget) = (0, Screen.width);
            }

            float minY = Screen.height / 10 * 2;
            float MaxY = Screen.height / 10 * 8;
            float y = Random.Range(minY, MaxY);

            return (new Vector3(xStart, y, 0), new Vector3(xTarget, y));
        }

        private void OnUFORealized()
        {
            ufoController.Realized -= OnUFORealized;

            ufoController.gameObject.SetActive(false);
            StartCoroutine(nameof(CreateUFO));
        }
    }
}
