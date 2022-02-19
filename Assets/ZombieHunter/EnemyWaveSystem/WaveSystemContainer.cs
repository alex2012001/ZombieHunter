using Leopotam.Ecs;
using ZombieHunter.MovementSystem;

namespace ZombieHunter.EnemyWaveSystem
{
    public class WaveSystemContainer : IEcsContainer
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
                .Add(new WaveSpawnSystem())
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