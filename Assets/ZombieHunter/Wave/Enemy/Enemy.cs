using System;
using System.Collections;
using UnityEngine;
using ZombieHunter.Player;

namespace Wave.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public Action OnAttack;

        [SerializeField] private EnemyConfig config;
        [SerializeField] private Transform particleSpawnpoint;
        
        private float _healhPoint;

        private void Start()
        {
            _healhPoint = config.HealthPoints;
        }

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
        private void OnTriggerEnter(Collider other)
        {
            OnAttack?.Invoke();
            if (other.CompareTag("Player"))
            {
                var player = other.GetComponent<ZombieHunter.Player.PlayerController>();

                player.TakeDamage(config.Damage);
            }
        }
       
        private IEnumerator DelayForDeletePartycle(GameObject partycle)
        {
            yield return new WaitForSeconds(config.TimeLivePartycle);
            
            Destroy(partycle.gameObject);
        }
    }
}