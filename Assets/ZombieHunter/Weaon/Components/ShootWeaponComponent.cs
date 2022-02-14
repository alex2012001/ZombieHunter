using System;
using UnityEngine;
using Voody.UniLeo;
using Weapon;

namespace ZombieHunter.Weaon.Components
{
    public class ShootWeaponComponent : MonoProvider<ShootData>
    {
        
    }

    [Serializable]
    public struct ShootData
    {
        private WeaponConfig weaponConfig;
        private GameObject effect;

        private ParticleSystem system;
    }
}