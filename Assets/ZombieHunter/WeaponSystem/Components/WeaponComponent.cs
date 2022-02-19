using System;
using Voody.UniLeo;

namespace ZombieHunter.WeaponSystem.Components
{
    public class WeaponComponent : MonoProvider<WeaponData>
    { }
    [Serializable]
    public struct WeaponData
    {
        public float Damage;
        public int FireRate;
    }
}