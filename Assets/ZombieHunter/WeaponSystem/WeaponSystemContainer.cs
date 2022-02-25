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
            var bulletViewCreator = new BulletViewCreator();

            ecsSystems
                .Inject(bulletViewCreator);
        }

        public void AddOneFrameObjects(EcsSystems ecsSystems)
        {
            ecsSystems
                .OneFrame<ShootRightHandEvent>()
                .OneFrame<ShootLeftHandEvent>();
        }
    }
}