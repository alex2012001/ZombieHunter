using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Events;
using ZombieHunter.PlayerInputSystem;

namespace ZombieHunter.MovementSystem
{
    public class MovementSystemsContainer : IEcsContainer
    {
        public void AddSystems(EcsSystems ecsSystems)
        {
            ecsSystems
                .Add(new BlockJumpSystem())
                .Add(new PlayerInputSystem.PlayerInputSystem())
                .Add(new DevInputSystem())
                .Add(new MovementSystem())
                .Add(new GroundCheckSystem())
                .Add(new PlayerJumpSystem());
        }

        public void AddInjectors(EcsSystems ecsSystems)
        {
            var inputConfig = Resources.Load<PlayerInputConfig>("PlayerInputConfig");

            ecsSystems
                .Inject(inputConfig);
        }

        public void AddOneFrameObjects(EcsSystems ecsSystems)
        {
            ecsSystems
                .OneFrame<JumpEvent>();
        }
    }
}