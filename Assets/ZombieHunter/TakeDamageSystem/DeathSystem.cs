using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.TakeDamageSystem.Components;
using ZombieHunter.TakeDamageSystem.Events;

namespace ZombieHunter.TakeDamageSystem
{
    public class DeathSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CheckDeathEvent,HealthpointsData, ModelData> _deathFilter = null;
        
        public void Run()
        {
            foreach (var i in _deathFilter)
            {
                Debug.Log("Check");
                ref var entity = ref _deathFilter.GetEntity(i);
                ref var healthpoints = ref _deathFilter.Get2(i);
                ref var model = ref _deathFilter.Get3(i);

                entity.Del<CheckDeathEvent>();
                
                if (healthpoints.Healthpoints <= 0f)
                {
                    Death(ref entity, ref model);
                }
            }
        }

        private void Death(ref EcsEntity entity, ref ModelData model)
        {
            Debug.Log("AAAAAAAAAAAAAAAAA");
            // TODO: add death effects for more entity
            entity.Destroy();
            Object.Destroy(model.ModelTransform.gameObject);
        }
    }
}