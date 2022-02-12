using System;
using UnityEngine;

namespace Wave
{
    [CreateAssetMenu(fileName = "WaveConfig", menuName = "WaveConfig")]
    public class WavesConfig : ScriptableObject
    {
        public Wave[] Waves;
    }

    [Serializable]
    public struct Wave
    {
        public Enemy.Enemy[] Enemies;
    }
}
