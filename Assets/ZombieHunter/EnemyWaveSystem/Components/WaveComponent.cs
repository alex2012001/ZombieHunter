using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.EnemyWaveSystem.Components
{
    public class WaveComponent : MonoProvider<WaveData>{ }
    
    [Serializable]
    public struct WaveData
    {
        public Transform[] EnemySpawnpoints;
        public WaveConfig WaveConfig;
    }
}