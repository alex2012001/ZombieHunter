using UnityEngine;

namespace ZombieHunter
{
    [CreateAssetMenu(fileName = "Wave", menuName = "Wave/WaveConfig")]
    public class WaveConfig : ScriptableObject
    {
        public int CountWaves;
        public int CountEnemyPerWave;
        public float DelayBetweenSpawn;
    }
}