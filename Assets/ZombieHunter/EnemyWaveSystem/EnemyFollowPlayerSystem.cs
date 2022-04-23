using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.EnemyWaveSystem.Components;
using ZombieHunter.MovementSystem.Components;

namespace ZombieHunter.EnemyWaveSystem
{
   sealed class EnemyFollowPlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tags.Enemy, FollowData> _enemyFollowDataFilter = null;
        private readonly EcsFilter<Tags.Enemy, EnemyData> _enemyDataFilter = null;
        private readonly EcsFilter<Tags.Player, ModelData> _playerFilter = null;
        private readonly EcsFilter<Tags.SavePoint, SavePointData> _savePointFilter = null;

        public void Run()
        {
            foreach (var i in _enemyFollowDataFilter)
            {
                ref var navMesh = ref _enemyFollowDataFilter.Get2(i).NavMeshAgent;
                ref var enemyDataConfig = ref _enemyDataFilter.Get2(i).Config;
                ref var posPlayer = ref _playerFilter.Get2(i).ModelTransform;
                ref var posSavePoint = ref _savePointFilter.Get2(i).SavePointTransform;

                if (posPlayer.transform.gameObject.activeSelf && Vector3.Distance(posPlayer.transform.position,navMesh.transform.position) < enemyDataConfig.DistanceChangeChoiseObjectAttack)
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