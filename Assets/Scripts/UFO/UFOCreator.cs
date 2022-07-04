using Assets.Scripts.Player;

using System.Collections;

using UnityEngine;

namespace Assets.Scripts.UFO
{
    public class UfoCreator : MonoBehaviour
    {
        private Ufo ufo;
        [SerializeField] private Transform playerShipTransform;
        [SerializeField] private PlayerInput playerInput;

        private void Awake()
        {
            ufo = Instantiate(Resources.Load<Ufo>("UFO"), transform);
            ufo.gameObject.SetActive(false);
            ufo.Setup(transform, playerShipTransform, playerInput);
        }

        private void Start()
        {
            StartCoroutine(nameof(CreateUfo));
        }

        private IEnumerator CreateUfo()
        {
            yield return new WaitForSeconds(Random.Range(20, 40));

            ufo.gameObject.SetActive(true);
            (Vector3 position, Vector3 target) = CalcPosAndTarget();

            ufo.Initialize(position, target);

            ufo.Realized += OnUFORealized;
        }

        private (Vector3, Vector3) CalcPosAndTarget()
        {
            (float xStart, float xTarget) = Random.Range(-1f, 1f) > 0 ?
                (Screen.width, 0) : (0, Screen.width);

            float minY = Screen.height / 10 * 2;
            float maxY = Screen.height / 10 * 8;
            float y = Random.Range(minY, maxY);

            return (new Vector3(xStart, y, 0), new Vector3(xTarget, y));
        }

        private void OnUFORealized()
        {
            ufo.Realized -= OnUFORealized;

            ufo.gameObject.SetActive(false);
            StartCoroutine(nameof(CreateUfo));
        }
    }
}
