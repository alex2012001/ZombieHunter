using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.WeaponSystem.MeleeWeapon
{
    public class MeleeWeaponComponent : MonoProvider<MeleeWeaponData>
    { }

    [Serializable]
    public struct MeleeWeaponData
    {
        public Collider Collider;
        public Rigidbody Rigidbody;
    }
}