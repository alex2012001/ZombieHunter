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
       
        private void TakeDamage(float damage)
        {
            config.HealthPoints -= damage;
            if ( config.HealthPoints <= 0)
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
                var player = other.GetComponent<Player>();
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