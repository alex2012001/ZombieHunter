using Leopotam.Ecs;
using ZombieHunter.EnemyWaveSystem;
using ZombieHunter.MovementSystem;
using ZombieHunter.Weaon.Components;

namespace ZombieHunter.Weaon.demo
{
    public class WeaponSystemContainer : IEcsContainer
    {
        public void AddSystems(EcsSystems ecsSystems)
        {
            ecsSystems
                .Add(new BlockJumpSystem())
                .Add(new PlayerInputSystem())
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

        }

        public void AddOneFrameObjects(EcsSystems ecsSystems)
        {

        }
    }
}