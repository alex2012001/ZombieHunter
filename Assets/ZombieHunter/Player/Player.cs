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
        [SerializeField] private float timeLivePartycle; 
        
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
            }
        }

        private IEnumerator DelayForDeletePartycle(GameObject partycle)
        {
            yield return new WaitForSeconds(timeLivePartycle);
            
            Destroy(partycle.gameObject);
        }
    }
}