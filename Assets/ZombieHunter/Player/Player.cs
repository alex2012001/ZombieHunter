using System;
using System.Collections;
using UnityEngine;
using Wave.Enemy;

namespace ZombieHunter.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform particleSpawnpoint;

        [SerializeField] private PlayerConfig config;
        
        private GameObject _particle;
        
        private float _healthPoints;
        private float _timeLivePartycle;
        private float _damage;

        private void Start()
        {
            _particle = config.Particle;
            _healthPoints = config.HealthPoints;
            _timeLivePartycle = config.TimeLivePartycle;
            _damage = config.Damage;
        }

        public void TakeDamage(float damage)
        {
            _healthPoints -= damage;
            if (_healthPoints <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                var part = Instantiate(_particle, particleSpawnpoint);
                StartCoroutine(DelayForDeletePartycle(part));
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                var enemy = other.GetComponent<Enemy>();
                enemy.TakeDamage(_damage);
            }
        }

        private IEnumerator DelayForDeletePartycle(GameObject partycle)
        {
            yield return new WaitForSeconds(_timeLivePartycle);
            
            Destroy(partycle.gameObject);
        }
    }
}