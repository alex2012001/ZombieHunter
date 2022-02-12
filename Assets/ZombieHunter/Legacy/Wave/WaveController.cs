using System.Collections;
using UnityEngine;
namespace Wave
{
    public class WaveController : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private LegacyWavesConfig legacyWavesConfig;

        [SerializeField] private int delayBetweenSpawn;

        private int _waveCounter = 0;
        private int _enemyCounter = 0;
        
        private void Start()
        {
            StartCoroutine(EnemySpawner());
        }        

        private IEnumerator EnemySpawner()
        {
            if (_enemyCounter >= legacyWavesConfig.Waves[_waveCounter]
                .Enemies.Length)
            {
                _waveCounter++;
                _enemyCounter = 0;
            }
            
            if (_waveCounter >= legacyWavesConfig.Waves.Length)
            {
                //TODO : Win
                yield break;
            }

            yield return new WaitForSeconds(delayBetweenSpawn);
            Instantiate(
                legacyWavesConfig.Waves[_waveCounter]
                    .Enemies[Random.Range(0, legacyWavesConfig.Waves[_waveCounter].Enemies.Length)],
                spawnPoints[Random.Range(0, spawnPoints.Length)]);

            _enemyCounter++;
            
            StartCoroutine(EnemySpawner());
        }
    }
}
