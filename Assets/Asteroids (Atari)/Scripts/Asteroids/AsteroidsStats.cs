using UnityEngine;

namespace Asteroids__Atari_.Scripts.Asteroids
{
    [CreateAssetMenu(fileName = "AsteroidsStats", menuName = "ScriptableObjects/AsteroidsStats", order = 1)]
    internal class AsteroidsStats : ScriptableObject
    {
        [SerializeField] private float delayBeforeRecreating;
        [SerializeField] private float expansionDegreeAfterDestroyAsteroid = 45;

        public float GetDelayBeforeRecreating()
        {
            return delayBeforeRecreating;
        }

        public float GetExpansionDegreeAfterDestroyAsteroid()
        {
            return delayBeforeRecreating;
        }
    }
}