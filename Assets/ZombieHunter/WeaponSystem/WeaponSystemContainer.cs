using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.WeaponSystem.Systems;

namespace ZombieHunter.WeaponSystem
{
    public class WeaponSystemContainer : IEcsContainer
    {
        public void AddSystems(EcsSystems ecsSystems)
        {
            ecsSystems
                .Add(new BulletFlyingSystem())
                .Add(new WeaponSpawnSystem())
                .Add(new PlayerWeaponShootSystem());
        }

        public void AddInjectors(EcsSystems ecsSystems)
        {
            var bulletConfig = Resources.Load<BulletConfig>("BulletConfig");

            ecsSystems
                .Inject(bulletConfig);
        }

        public void AddOneFrameObjects(EcsSystems ecsSystems)
        {
            ecsSystems
                .OneFrame<ShootRightHandEvent>()
                .OneFrame<ShootLeftHandEvent>();
        }
    }
}