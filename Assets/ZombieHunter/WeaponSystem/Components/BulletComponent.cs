using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.WeaponSystem.Components
{
    public class BulletComponent: MonoProvider<BulletData>
    {
        
    }
    [Serializable]
    public struct BulletData
    {
        [HideInInspector] public float Damage;
        [HideInInspector] public Collider Collision;
    }
}