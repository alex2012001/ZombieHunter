using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.MovementSystem.Components
{
    public class MovableComponent : MonoProvider<MovableData>{ }
    
    [Serializable]
    public struct MovableData
    {
        public CharacterController CharacterController;
        public float Speed;
    }
}