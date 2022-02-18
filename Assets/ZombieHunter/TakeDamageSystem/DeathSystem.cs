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
                ref var healthpoints = ref _deathFilter.Get2(i);
                ref var model = ref _deathFilter.Get3(i);

                if (healthpoints.Healthpoints <= 0f)
                {
                    Death(ref model);
                }
            }
        }

        private void Death(ref ModelData model)
        {
            // TODO: add deatheffects for mode entity
           // GameObject.Destroy(model.ModelTransform.gameObject);
            Debug.Log("Death!");
            
            
        }
    }
}