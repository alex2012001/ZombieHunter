using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.TakeDamageSystem.Events;

namespace ZombieHunter.WeaponSystem
{
    public class BulletView : ViewObject
    {
        public float Damage { get; set; }

        private readonly string EnemyTag = "Enemy";
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag(EnemyTag))
            {
                Debug.Log("AAAAAAAAAAAAAAA");
                var entityReference = other.GetComponent<EntityReference>();
                var entity = entityReference.Entity;
                
                entity.Replace(new TakeDamageEvent 
                { 
                    Damage = Damage
                });
            }
        }
    }
}