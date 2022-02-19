﻿using UnityEngine;

namespace ZombieHunter.WeaponSystem
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        public float Damage;
        public float Speed;
        public int DestroyDelay;
    }
}