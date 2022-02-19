using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.EnemyWaveSystem.Components;
using ZombieHunter.Tags;

namespace ZombieHunter.EnemyWaveSystem
{
    sealed class WaveSpawnSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<WaveData> _waveDataFilter = null;

        private WaveConfig _waveConfig;
        private Transform[] _posToSpawn;
        private EnemyTag[] _prefabsEnemyes;

        private int _enemyCounter;
        public void Init()
        {
            foreach (var i in _waveDataFilter)
            {
               _waveConfig = _waveDataFilter.Get1(i).WaveConfig;
               _posToSpawn = _waveDataFilter.Get1(i).EnemySpawnpoints;
               
               _prefabsEnemyes = Resources.LoadAll<EnemyTag>("EnemyPrefabs");
               
               _enemyCounter = _waveConfig.CountEnemyPerWave;
            }
        }
        
        public void Run()
        {
            if (_enemyCounter > 0)
            {
                SpawnEnemy(_posToSpawn, _prefabsEnemyes);
            }
        }

        private void SpawnEnemy(Transform[] pos, EnemyTag[] prefabs)
        {
            var randPos = pos[Random.Range(0, pos.Length)];
            var randPrefab = prefabs[Random.Range(0, prefabs.Length)].gameObject;
            
            Object.Instantiate(randPrefab, randPos);
            
            _enemyCounter--;
        }
    }
}