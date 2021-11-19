using System;
using System.Collections;
using UnityEngine;
using User;

namespace Wave.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float healthPoints;
        [SerializeField] private GameObject particle;
        [SerializeField] private Transform particleSpawnpoint;
        
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
            yield return new WaitForSeconds(0.5f);
            
            Destroy(partycle.gameObject);
        }
    }
}