using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.WeaponSystem.Components
{
    public class WeaponSpawnComponent : MonoProvider<WeaponSpawnData>
    { }

    [Serializable]
    public struct WeaponSpawnData
    {
        public Transform RightHandTransform;
        public Transform LeftHandTransform;
    }
}