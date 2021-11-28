using System;
using System.Collections;
using UnityEngine;

namespace ZombieHunter.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerConfig config;
        [SerializeField] private Transform particleSpawnpoint;

        private float _healhPoint;
        public void TakeDamage(float damage)
        {
            _healhPoint -= damage;
            if (_healhPoint <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                var part = Instantiate(config.Particle, particleSpawnpoint);
                StartCoroutine(DelayForDeletePartycle(part));
            }
        }
        private void Start()
        {
            _healhPoint = config.HealthPoints;
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