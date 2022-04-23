using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.MovementSystem.Components
{
    public class SavePointModeComponent : MonoProvider<SavePointData>
    {

    }
    
    [Serializable]
    public struct SavePointData
    {
        public Transform SavePointTransform;
    }
}