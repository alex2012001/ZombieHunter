using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.ZInputSystem;
using ZombieHunter.MovementSystem.Events;

namespace ZombieHunter.MovementSystem
{
    public class MovementSystemsContainer : IEcsContainer
    {
        public void AddSystems(EcsSystems ecsSystems)
        {
            ecsSystems
                .Add(new BlockJumpSystem())
                .Add(new DeveloperInputSystem.DeveloperInputSystem())
                .Add(new PlayerInputSystem.PlayerInputSystem())
                .Add(new MouseLookSystem.MouseLookSystem())
                .Add(new MovementSystem())
                .Add(new GroundCheckSystem())
                .Add(new PlayerJumpSystem());
        }

        public void AddInjectors(EcsSystems ecsSystems)
        {
            var inputConfig = Resources.Load<InputConfig>("InputConfig");

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