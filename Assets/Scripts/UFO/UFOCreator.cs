using System.Collections;

using UnityEngine;

namespace Assets.Scripts.UFO
{
    public class UFOCreator : MonoBehaviour
    {
        private UFOController ufoController;
        [SerializeField] private Transform playerShipTransform;

        private void Awake()
        {
            ufoController = Instantiate(Resources.Load<UFOController>("UFO"), transform);
            ufoController.gameObject.SetActive(false);
            ufoController.Setup(transform, playerShipTransform);
        }

        private void Start()
        {
            StartCoroutine(nameof(CreateUFO));
        }

        private IEnumerator CreateUFO()
        {
           // yield return new WaitForSeconds(Random.Range(20, 40));
            yield return null;

            ufoController.gameObject.SetActive(true);
            (float x, float xTarget) = Random.Range(-1f, 1f) > 0 ? (Screen.width, 0) : (0, Screen.width);
            float y = Random.Range(0, Screen.height);
            ufoController.Initialize(new Vector3(x, y, 0), new Vector3(xTarget, y));

            ufoController.Realized += OnUFORealized;
        }

        private void OnUFORealized()
        {
            ufoController.Realized -= OnUFORealized;

            ufoController.gameObject.SetActive(false);
            StartCoroutine(nameof(CreateUFO));
        }
    }
}
