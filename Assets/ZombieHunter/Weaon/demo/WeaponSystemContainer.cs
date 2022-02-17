﻿using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.EnemyWaveSystem;
using ZombieHunter.MovementSystem;
using ZombieHunter.MovementSystem.Events;
using ZombieHunter.PlayerInputSystem;
using ZombieHunter.Weapon;

namespace ZombieHunter.Weaon
{
    public class WeaponSystemContainer : IEcsContainer
    {
        public void AddSystems(EcsSystems ecsSystems)
        {
            ecsSystems
                .Add(new BulletFlyingSystem())
                .Add(new EnemyFollowPlayerSystem())
                .Add(new WeaponSpawnSystem())
                .Add(new WeaponShootSystem())

                ;
        }

        public void AddInjectors(EcsSystems ecsSystems)
        {
            var bullet = Resources.Load<BulletComponent>("Bullet");
            var weapon = Resources.Load<WeaponComponent>("Handgun");
           
            var weaponConfig = Resources.Load<WeaponConfig>("WeaponConfig");

            ecsSystems
                .Inject(bullet)
                .Inject(weapon)
                .Inject(weaponConfig)
                
                ;
        }

        public void AddOneFrameObjects(EcsSystems ecsSystems)
        {
            ecsSystems
                .OneFrame<JumpEvent>()
                .OneFrame<ShootRightHandEvent>()
                .OneFrame<ShootLeftHandEvent>()
                ;
        }
    }
}