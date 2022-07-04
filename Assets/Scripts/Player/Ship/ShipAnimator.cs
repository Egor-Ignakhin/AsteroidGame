using Assets.Scripts.Player.Ship.ShipStates;

using System.Collections;
using Assets.Scripts.Player.Ship.States;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Player.Ship
{
    public class ShipAnimator : MonoBehaviour
    {
        [SerializeField] private ShipController shipController;
        [SerializeField] private Image imgRenderer;

        private void OnEnable()
        {
            shipController.StateChanged += OnShipStateChanged;
        }

        private void OnShipStateChanged()
        {
            StopAllCoroutines();

            if (shipController.GetState() is InvulnerabilityShipState)
            {
                StartCoroutine(nameof(InvulnerabilityIndicate));
                shipController.transform.position = new Vector3(Screen.width / 2f, Screen.height / 2f);
            }
            else if (shipController.GetState() is MainShipState)
            {
                imgRenderer.enabled = true;
            }
        }

        private IEnumerator InvulnerabilityIndicate()
        {
            float timeIndicatingSec = 3f;
            float indicatingFrequency = 0.25f;

            for (int i = 0; i < timeIndicatingSec / indicatingFrequency; i++)
            {
                imgRenderer.enabled = !imgRenderer.enabled;
                yield return new WaitForSeconds(indicatingFrequency);
            }
            imgRenderer.enabled = true;
        }

        private void OnDisable()
        {
            shipController.StateChanged -= OnShipStateChanged;
        }
    }
}
