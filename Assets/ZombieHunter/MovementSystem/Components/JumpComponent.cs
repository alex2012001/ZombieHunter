using System;
using Voody.UniLeo;

namespace ZombieHunter.MovementSystem.Components
{
    public class JumpComponent : MonoProvider<JumpData>
    {
        
    }

    [Serializable]
    public struct JumpData
    {
        public float Force;
    }
}