using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.MovementSystem.Components
{
    public class ModelComponent : MonoProvider<ModelData>
    {
        
    }
    
    [Serializable]
    public struct ModelData
    {
        public Transform ModelTransform;
    }
}