using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.Weaon
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