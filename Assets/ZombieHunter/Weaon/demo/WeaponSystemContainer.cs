using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.EnemyWaveSystem;
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
            var weaponConfig = Resources.Load<WeaponConfig>("WeaponConfig");
            var weapon = Resources.Load<WeaponComponent>("Handgun");

            var bulletConfig = Resources.Load<BulletConfig>("BulletConfig");
            var bullet = Resources.Load<BulletComponent>("Bullet");

            ecsSystems
                .Inject(weaponConfig)
                .Inject(weapon)
                
                .Inject(bulletConfig)
                .Inject(bullet)
                ;
        }

        public void AddOneFrameObjects(EcsSystems ecsSystems)
        {
            ecsSystems
                .OneFrame<ShootRightHandEvent>()
                .OneFrame<ShootLeftHandEvent>()
                ;
        }
    }
}