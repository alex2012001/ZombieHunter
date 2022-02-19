using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.WeaponSystem.Components
{
    public class WeaponSpawnComponent : MonoProvider<WeaponData>
    { }

    [Serializable]
    public struct WeaponData
    {
        public Transform RightHandTransform;
        public Transform LeftHandTransform;
        public Transform BulletContainer;
    }
}