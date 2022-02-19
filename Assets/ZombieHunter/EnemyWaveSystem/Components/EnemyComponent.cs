using System;
using UnityEngine;
using Voody.UniLeo;
using Wave.Enemy;

namespace ZombieHunter.EnemyWaveSystem.Components
{
    public class EnemyComponent : MonoProvider<EnemyData>{ }
    
    [Serializable]
    public struct EnemyData
    {
        public EnemyConfig Config;
        public Transform ParticleSpawnpoint;
    }
}