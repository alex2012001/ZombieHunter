using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.EnemyWaveSystem.Components;
using ZombieHunter.MovementSystem.Components;

namespace ZombieHunter.EnemyWaveSystem
{
   sealed class EnemyFollowPlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tags.Enemy, FollowData, EnemyData, ModelData> _enemyDataFilter = null;
        private readonly EcsFilter<Tags.Player, ModelData> _playerFilter = null;
        private readonly EcsFilter<Tags.SavePoint, ModelData> _savePointFilter = null;

        public void Run()
        {
            foreach (var i in _enemyDataFilter)
            {
                ref var navMesh = ref _enemyDataFilter.Get2(i).NavMeshAgent;
                ref var enemyTransform = ref _enemyDataFilter.Get4(i).ModelTransform;
                ref var enemyDataConfig = ref _enemyDataFilter.Get3(i).Config;
                ref var posPlayer = ref _playerFilter.Get2(0).ModelTransform;
                ref var posSavePoint = ref _savePointFilter.Get2(0).ModelTransform;
                
                if (Vector3.Distance(posPlayer.position,enemyTransform.position) 
                    < enemyDataConfig.DistanceChangeChoiseObjectAttack)
                {
                    navMesh.SetDestination(posPlayer.position);
                }
                else
                {
                    navMesh.SetDestination(posSavePoint.position);
                }
            }
        }
    }
}