using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MouseLookSystem;
using ZombieHunter.MovementSystem.Events;
using ZombieHunter.InputSystem;

namespace ZombieHunter.MovementSystem
{
    public class MovementSystemsContainer : IEcsContainer
    {
        public void AddSystems(EcsSystems ecsSystems)
        {
            ecsSystems
                .Add(new BlockJumpSystem())
                .Add(new PlayerInputSystem())
                .Add(new DevInputSystem())
                //.Add(new MouseLookSystem.MouseLookSystem())
                //.Add(new MouseInputSystem())
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