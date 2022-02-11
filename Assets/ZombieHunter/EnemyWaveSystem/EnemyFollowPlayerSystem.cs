using Leopotam.Ecs;
using ZombieHunter.EnemyWaveSystem.Components;
namespace ZombieHunter.EnemyWaveSystem
{
   sealed class EnemyFollowPlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tags.Enemy, FollowData> _enemyFollowDataFilter = null;

        public void Run()
        {
            foreach (var i in _enemyFollowDataFilter)
            {
                ref var navMesh = ref _enemyFollowDataFilter.Get2(i).NavMeshAgent;

                navMesh.SetDestination(PlayerParameters.PlayerTransform.position);

            }
        }
    }
}