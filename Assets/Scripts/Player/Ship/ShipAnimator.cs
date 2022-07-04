using System.Collections;
using Assets.Scripts.Player.Ship.States;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Player.Ship
{
    public class ShipAnimator : MonoBehaviour
    {
        [SerializeField] private Ship ship;
        [SerializeField] private Image imgRenderer;

        private void OnEnable()
        {
            ship.StateChanged += OnShipStateChanged;
        }

        private void OnShipStateChanged()
        {
            StopAllCoroutines();

            if (ship.GetState() is InvulnerabilityShipState)
            {
                StartCoroutine(nameof(InvulnerabilityIndicate));
                ship.transform.position = new Vector3(Screen.width / 2f, Screen.height / 2f);
            }
            else if (ship.GetState() is MainShipState)
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
            ship.StateChanged -= OnShipStateChanged;
        }
    }
}
