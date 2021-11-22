using System.Collections;
using UnityEngine;
using ZombieHunter.Player;

namespace Wave.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyConfig config;
        [SerializeField] private Transform particleSpawnpoint;

        private float _healthPoints;
        private float _timeLivePartycle;
        private float _damage;
        
        private GameObject _particle;
       

        private void Start()
        {
            _healthPoints = config.HealthPoints;
            _particle = config.Particle;
            _timeLivePartycle = config.TimeLivePartycle;
            _damage = config.Damage;
        }
        
        public void TakeDamage(float dmg)
        {
            _healthPoints -= dmg;
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
            if (other.CompareTag("Player"))
            {
                var player = other.GetComponent<Player>();
                player.TakeDamage(_damage);
            }
        }
       
        private IEnumerator DelayForDeletePartycle(GameObject partycle)
        {
            yield return new WaitForSeconds(_timeLivePartycle);
            
            Destroy(partycle.gameObject);
        }
    }
}