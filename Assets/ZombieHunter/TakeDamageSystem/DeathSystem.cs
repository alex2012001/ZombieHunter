using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.TakeDamageSystem.Components;
using ZombieHunter.TakeDamageSystem.Events;

namespace ZombieHunter.TakeDamageSystem
{
    public class DeathSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tags.Player,CheckDeathEvent,HealthpointsData, ModelData> _playerDeathFilter = null;
        private readonly EcsFilter<Tags.Enemy,CheckDeathEvent,HealthpointsData, ModelData> _enemyDeathFilter = null;
        
        public void Run()
        {
            foreach (var i in _enemyDeathFilter)
            {
                Debug.Log("Check");
                ref var entity = ref _enemyDeathFilter.GetEntity(i);
                ref var healthpoints = ref _enemyDeathFilter.Get3(i);
                ref var model = ref _enemyDeathFilter.Get4(i);

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