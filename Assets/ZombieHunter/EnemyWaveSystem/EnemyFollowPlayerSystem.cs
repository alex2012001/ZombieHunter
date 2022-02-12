using Leopotam.Ecs;
using ZombieHunter.EnemyWaveSystem.Components;
using ZombieHunter.MovementSystem.Components;

namespace ZombieHunter.EnemyWaveSystem
{
   sealed class EnemyFollowPlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tags.Enemy, FollowData> _enemyFollowDataFilter = null;
        private readonly EcsFilter<Tags.Player, ModelData> _playerFilter = null;

        public void Run()
        {
            foreach (var i in _enemyFollowDataFilter)
            {
                ref var navMesh = ref _enemyFollowDataFilter.Get2(i).NavMeshAgent;
                ref var posPlayer = ref _playerFilter.Get2(i).ModelTransform;

               navMesh.SetDestination(posPlayer.position);
            }
        }
    }
}