using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.WeaponSystem.MeleeWeapon
{
    public class BladeComponent : MonoProvider<BladeData>
    { }

    [Serializable]
    public struct BladeData
    {
        public float Damage;
        public bool IsReady;
        public Collider Collider;
    }
}