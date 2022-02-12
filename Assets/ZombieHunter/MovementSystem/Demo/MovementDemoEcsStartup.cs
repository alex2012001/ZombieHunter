using ZombieHunter.MovementSystem.Events;

namespace ZombieHunter.MovementSystem.Demo
{
    public class MovementDemoEcsStartup : EcsStartup
    {
        protected override void AddSystems()
        {
            _systems
                .Add(new BlockJumpSystem())
                .Add(new PlayerInputSystem())
                .Add(new MovementSystem())
                .Add(new GroundCheckSystem())
                .Add(new PlayerJumpSystem());
        }

        protected override void AddOneFrames()
        {
            _systems
                .OneFrame<JumpEvent>();
        }
    }
}