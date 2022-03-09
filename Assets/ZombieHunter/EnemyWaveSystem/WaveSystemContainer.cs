using Leopotam.Ecs;

namespace ZombieHunter.EnemyWaveSystem
{
    public class WaveSystemContainer : IEcsContainer
    {
        public void AddSystems(EcsSystems ecsSystems)
        {
            ecsSystems
                .Add(new EnemyFollowPlayerSystem())
                .Add(new WaveSpawnSystem());
        }

        public void AddInjectors(EcsSystems ecsSystems)
        {
            
        }

        public void AddOneFrameObjects(EcsSystems ecsSystems)
        {
            
        }
    }
}