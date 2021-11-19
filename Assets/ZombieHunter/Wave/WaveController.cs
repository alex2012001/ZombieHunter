using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
namespace Wave
{
    public class WaveController : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private WavesConfig wavesConfig;

        [SerializeField] private int delayBetweenSpawn;

        private int _waveCounter = 0;
        private int _enemyCounter = 0;
        
        private void Start()
        {
            StartCoroutine(EnemySpawner());
        }
        

        private IEnumerator EnemySpawner()
        {
            if (_enemyCounter >= wavesConfig.Waves[_waveCounter]
                .Enemies.Length)
            {
                _waveCounter++;
                _enemyCounter = 0;
            }
            
            if (_waveCounter >= wavesConfig.Waves.Length)
            {
                //TODO : Win
                yield break;
            }

            yield return new WaitForSeconds(delayBetweenSpawn);
            Instantiate(
                wavesConfig.Waves[_waveCounter]
                    .Enemies[Random.Range(0, wavesConfig.Waves[_waveCounter].Enemies.Length)],
                spawnPoints[Random.Range(0, spawnPoints.Length)]);

            _enemyCounter++;
            
            StartCoroutine(EnemySpawner());
        }
    }
}
