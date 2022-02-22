using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MouseLookSystem;
using ZombieHunter.MovementSystem.Events;
using ZombieHunter.PlayerInputSystem;

namespace ZombieHunter.MovementSystem
{
    public class MovementSystemsContainer : IEcsContainer
    {
        private readonly EcsStartup.DevelopMode _devMode = null;
        
        public void AddSystems(EcsSystems ecsSystems)
        {
            #region MouseLookDevMode

            if (_devMode.Value)
            {
                ecsSystems
                    .Add(new MouseLookSystem.MouseLookSystem())
                    .Add(new MouseInputSystem());
            }

            #endregion
            
            ecsSystems
                .Add(new BlockJumpSystem())
                .Add(new PlayerInputSystem.PlayerInputSystem())
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