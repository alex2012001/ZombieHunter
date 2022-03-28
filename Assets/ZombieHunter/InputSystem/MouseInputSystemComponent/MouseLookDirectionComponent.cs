﻿using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.InputSystem.MouseInputSystemComponent
{
    public class MouseLookDirectionComponent : MonoProvider<MouseLookDirectionData>
    {
        
    }
    [Serializable]
    public struct MouseLookDirectionData
    {
        public Vector3 Direction;
        public float MouseSensitivity;
        public Transform CameraTransform;
    }
}