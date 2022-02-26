using Leopotam.Ecs;
using ZombieHunter.TakeDamageSystem.Events;

namespace ZombieHunter.TakeDamageSystem
{
    public class TakeDamageSystemsContainer : IEcsContainer
    {
        public void AddSystems(EcsSystems ecsSystems)
        {
            ecsSystems
                .Add(new TakeDamageSystem())
                .Add(new DeathSystem());
        }

        public void AddInjectors(EcsSystems ecsSystems)
        {
            
        }

        public void AddOneFrameObjects(EcsSystems ecsSystems)
        {
            
        }
    }
}