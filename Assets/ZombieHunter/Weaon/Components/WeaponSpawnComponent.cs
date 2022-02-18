using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.Weaon
{
    public class WeaponSpawnComponent : MonoProvider<WeaponData>
    {
        
    }

    [Serializable]
    public struct WeaponData
    {
        public Transform RightHandTransform;
        public Transform LeftHandTransform;
        public Transform BulletContainer;
    }
}