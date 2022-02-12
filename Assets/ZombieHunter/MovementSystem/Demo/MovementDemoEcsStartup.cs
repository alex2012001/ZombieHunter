
namespace ZombieHunter.MovementSystem.Demo
{
    public class MovementDemoEcsStartup : EcsStartup
    {
        private readonly MovementSystemsContainer _movementSystemsContainer = new MovementSystemsContainer();
        
        protected override void AddSystems()
        {
            _movementSystemsContainer.AddSystems(_systems);
        }

        protected override void AddOneFrames()
        {
            _movementSystemsContainer.AddOneFrameObjects(_systems);
        }

        protected override void AddInjections()
        {
            _movementSystemsContainer.AddInjectors(_systems);
        }
    }
}