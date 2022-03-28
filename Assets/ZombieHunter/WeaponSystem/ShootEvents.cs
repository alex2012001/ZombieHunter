using UnityEngine;

namespace ZombieHunter.WeaponSystem
{
    internal struct ShootRightHandEvent
    {
        public float Damage { get; set; }
        public int FireRate { get; set; }
        public Transform FirePoint { get; set; }
    }
    internal struct ShootLeftHandEvent
    {
        public float Damage { get; set; }
        public int FireRate { get; set; }
        public Transform FirePoint { get; set; }
    }
}