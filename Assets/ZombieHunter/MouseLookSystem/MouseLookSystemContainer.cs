using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Events;
using ZombieHunter.PlayerInputSystem;

namespace ZombieHunter.MouseLookSystem
{
    public class MouseLookSystemContainer : IEcsContainer
    {
        public void AddSystems(EcsSystems ecsSystems)
        {
            ecsSystems
                .Add(new PlayerInputSystem.PlayerInputSystem())
                .Add(new MouseLookSystem())
                .Add(new MouseInputSystem());
        }

        public void AddInjectors(EcsSystems ecsSystems)
        {
            var inputConfig = Resources.Load<PlayerInputConfig>("PlayerInputConfig");

            ecsSystems
                .Inject(inputConfig);
        }

        public void AddOneFrameObjects(EcsSystems ecsSystems)
        {
                
        }
    }
}