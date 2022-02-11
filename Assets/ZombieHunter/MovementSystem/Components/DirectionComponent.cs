﻿using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.MovementSystem.Components
{
    public class DirectionComponent : MonoProvider<DirectionData>
    {
        
    }
    
    [Serializable]
    public struct DirectionData
    {
        [HideInInspector] public Vector3 Direction;
    }
}