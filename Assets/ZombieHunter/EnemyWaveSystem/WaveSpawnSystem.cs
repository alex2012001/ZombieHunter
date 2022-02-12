using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.EnemyWaveSystem.Components;

namespace ZombieHunter.EnemyWaveSystem
{
    sealed class WaveSpawnSystem : IEcsRunSystem
    {
        private readonly EcsFilter<WaveData> _waveDataFilter = null;

        private int _enemyCounter;
        public void Run()
        {
            foreach (var i in _waveDataFilter)
            {
                ref var prefabs = ref _waveDataFilter.Get1(i).PrefabsEnemy;
                ref var positions = ref _waveDataFilter.Get1(i).EnemySpawnpoints;

                if (_enemyCounter<5)
                {
                    SpawnEnemy(
                        positions[Random.Range(0, positions.Length)], 
                        prefabs[Random.Range(0, prefabs.Length)]);
                }
            }
        }

        private void SpawnEnemy(Transform pos, GameObject prefab)
        {
            GameObject.Instantiate(prefab, pos);
            _enemyCounter++;
        }
    }
}