using System.Threading.Tasks;
using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.TakeDamageSystem.Components;
using ZombieHunter.TakeDamageSystem.Events;

namespace ZombieHunter.TakeDamageSystem
{
    public class TakeDamageSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tags.Player, TakeDamageEvent, HealthpointsData> _playerDamageFilter = null;
        private readonly EcsFilter<Tags.Enemy, TakeDamageEvent, HealthpointsData> _enemyDamageFilter = null;

        public void Run()
        {
            foreach (var i in _playerDamageFilter)
            {
                ref var entity = ref _playerDamageFilter.GetEntity(i);
                ref var damageEvent = ref _playerDamageFilter.Get2(i);
                ref var healthpoints = ref _playerDamageFilter.Get3(i);
                
                TakeDamage(ref entity,ref healthpoints, damageEvent);
            }

            foreach (var i in _enemyDamageFilter)
            {
                ref var entity = ref _enemyDamageFilter.GetEntity(i);
                ref var damageEvent = ref _enemyDamageFilter.Get2(i);
                ref var healthpoints = ref _enemyDamageFilter.Get3(i);
                
                TakeDamage(ref entity ,ref healthpoints, damageEvent);
            }
        }

        private void TakeDamage(ref EcsEntity entity ,ref HealthpointsData hpData, TakeDamageEvent damage)
        {
            hpData.Healthpoints -= damage.Damage;
            entity.Get<CheckDeathEvent>();
        }
    }
}