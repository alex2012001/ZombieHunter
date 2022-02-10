using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.MovementSystem.Components
{
    public class GroundCheckComponent : MonoProvider<GroundCheckData>
    {
        
    }

    [Serializable]
    public struct GroundCheckData
    {
        public bool IsGrounded;
        public LayerMask GroundMask;
        public Transform GroundCheckSphere;
        public float GroundDistance;
    }
}