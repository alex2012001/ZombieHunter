using System.Collections;
using UnityEngine;
using Wave.Enemy;

namespace ZombieHunter.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float healthPoints;
        [SerializeField] private GameObject particle;
        [SerializeField] private Transform particleSpawnpoint;

        private bool isTakeingDamage;
        
        public void TakeDamage(float damage)
        {
            healthPoints -= damage;
            if (healthPoints <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                var part = Instantiate(particle, particleSpawnpoint);
                StartCoroutine(DelayForDeletePartycle(part));
                Debug.Log(healthPoints);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                var enemy = other.GetComponent<Enemy>();
                TakeDamage(enemy.GetDamageNumber());
            }
        }
        private IEnumerator DelayForDeletePartycle(GameObject partycle)
        {
            yield return new WaitForSeconds(5f);
            
            Destroy(partycle.gameObject);
        }
    }
}