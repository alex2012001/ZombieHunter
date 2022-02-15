using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.EnemyWaveSystem;
using ZombieHunter.MovementSystem;
using ZombieHunter.Weapon;

namespace ZombieHunter.Weaon
{
    public class WeaponSystemContainer : IEcsContainer
    {
        public void AddSystems(EcsSystems ecsSystems)
        {
            ecsSystems
                .Add(new BlockJumpSystem())
                .Add(new PlayerInputSystem.PlayerInputSystem())
                .Add(new MovementSystem.MovementSystem())
                .Add(new GroundCheckSystem())
                .Add(new PlayerJumpSystem())
                .Add(new EnemyFollowPlayerSystem())
                .Add(new WeaponSpawnSystem())
                .Add(new ShootWeaponSystem())
               
                ;
        }

        public void AddInjectors(EcsSystems ecsSystems)
        {
            var bullet = Resources.Load<Bullet>("Bullet");
            var weapon = Resources.Load<global::Weapon>("Handgun");
            var shootAnim = Animator.StringToHash("Shoot");

            var weaponConfig = Resources.Load<WeaponConfig>("WeaponConfig");
            

            ecsSystems
                .Inject(bullet)
                .Inject(weapon)
                .Inject(shootAnim)
                .Inject(weaponConfig)
                ;
        }

        public void AddOneFrameObjects(EcsSystems ecsSystems)
        {

        }
    }
}