﻿using UnityEngine;
using ZombieHunter.WeaponSystem.Components;

namespace ZombieHunter.WeaponSystem
{
    public class BulletViewCreator
    {
        public T Create<T>(T prefab, Transform container) where T : ViewObject
        {
            return Object.Instantiate(prefab, container);
        }
    }
}