using Leopotam.Ecs;
using ZombieHunter.MovementSystem.Events;

namespace ZombieHunter.MovementSystem
{
    public class MovementSystemsContainer : IEcsContainer
    {
        public void AddSystems(EcsSystems ecsSystems)
        {
            ecsSystems
                .Add(new BlockJumpSystem())
                .Add(new PlayerInputSystem())
                .Add(new MovementSystem())
                .Add(new GroundCheckSystem())
                .Add(new PlayerJumpSystem());
        }

        public void AddInjectors(EcsSystems ecsSystems)
        {
            
        }

        public void AddOneFrameObjects(EcsSystems ecsSystems)
        {
            ecsSystems
                .OneFrame<JumpEvent>();
        }
    }
}