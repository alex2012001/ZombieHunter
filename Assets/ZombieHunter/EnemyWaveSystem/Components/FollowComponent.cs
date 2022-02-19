using System;
using UnityEngine;
using UnityEngine.AI;
using Voody.UniLeo;

namespace ZombieHunter.EnemyWaveSystem.Components
{
    public class FollowComponent : MonoProvider<FollowData>{ }
    
    [Serializable]
    public struct FollowData
    {
        public NavMeshAgent NavMeshAgent;
    }
}