using Leopotam.Ecs;
using ZombieHunter.TakeDamageSystem.Components;
using ZombieHunter.TakeDamageSystem.Events;

namespace ZombieHunter.TakeDamageSystem
{
    public class TakeDamageSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TakeDamageEvent, HealthpointsData> _damageFilter = null;

        public void Run()
        {
            foreach (var i in _damageFilter)
            {
                ref var entity = ref _damageFilter.GetEntity(i);
                ref var damageEvent = ref _damageFilter.Get1(i);
                ref var healthpoints = ref _damageFilter.Get2(i);
                
                entity.Del<TakeDamageEvent>();
                TakeDamage(ref entity,ref healthpoints, damageEvent);
            }
        }

        private void TakeDamage(ref EcsEntity entity ,ref HealthpointsData hpData, TakeDamageEvent damage)
        {
            hpData.Healthpoints -= damage.Damage;
            entity.Get<CheckDeathEvent>();
        }
    }
}