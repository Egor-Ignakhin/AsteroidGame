using UnityEngine;

namespace Assets.Scripts
{
    public class WorldBorderGuard : MonoBehaviour
    {
        private void FixedUpdate()
        {
            if (transform.position.y > Screen.height)
            {
                transform.position = new Vector3(transform.position.x, 0);
            }
            if (transform.position.y < 0)
            {
                transform.position = new Vector3(transform.position.x, Screen.height);
            }

            if (transform.position.x > Screen.width)
            {
                transform.position = new Vector3(0, transform.position.y);
            }
            if (transform.position.x < 0)
            {
                transform.position = new Vector3(Screen.width, transform.position.y);
            }
        }
    }
}
