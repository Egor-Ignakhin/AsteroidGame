using UnityEngine;

namespace AnimationsIntegration.Scripts.Player
{
    public class PlayerSpineAnimator : MonoBehaviour
    {
        [SerializeField] private Transform spine;

        private void LateUpdate()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100000, ~0, QueryTriggerInteraction.Ignore))
            {
                var direction = transform.position - hit.point;
                direction.y = 0;
                direction.z = 0;
                spine.localEulerAngles = direction ;
            }
        }
    }
}
