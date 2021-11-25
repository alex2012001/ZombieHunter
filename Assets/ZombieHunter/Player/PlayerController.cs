using System.Collections;
using UnityEngine;

namespace ZombieHunter.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerConfig config;
        [SerializeField] private Transform particleSpawnpoint;

        public void TakeDamage(float damage)
        {
            config.HealthPoints -= damage;
            if (config.HealthPoints <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                var part = Instantiate(config.Particle, particleSpawnpoint);
                StartCoroutine(DelayForDeletePartycle(part));
            }
        }
        private void Awake()
        {
            PlayerParameters.PlayerTransform = transform;
        }

        private IEnumerator DelayForDeletePartycle(GameObject partycle)
        {
            yield return new WaitForSeconds(config.TimeLivePartycle);
            
            Destroy(partycle.gameObject);
        }
    }
}