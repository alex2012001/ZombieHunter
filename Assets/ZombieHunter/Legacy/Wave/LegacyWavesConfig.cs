using System;
using UnityEngine;

namespace Wave
{
    [CreateAssetMenu(fileName = "LegacyWaveConfig", menuName = "WaveConfig")]
    public class LegacyWavesConfig : ScriptableObject
    {
        public Wave[] Waves;
    }

    [Serializable]
    public struct Wave
    {
        public Enemy.Enemy[] Enemies;
    }
}
