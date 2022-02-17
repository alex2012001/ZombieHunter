using ZombieHunter.MovementSystem;

namespace ZombieHunter.TakeDamageSystem.Demo
{
    public class TakeDamageDemoStartup : EcsStartup
    {
        private readonly MovementSystemsContainer _movementSystemsContainer = new MovementSystemsContainer();
        private readonly TakeDamageSystemsContainer _takeDamageSystemsContainer = new TakeDamageSystemsContainer();
        
        protected override void AddSystems()
        {
            base.AddSystems();
            
            _movementSystemsContainer.AddSystems(_systems);
            _takeDamageSystemsContainer.AddSystems(_systems);
        }

        protected override void AddOneFrames()
        {
            base.AddOneFrames();
            
            _movementSystemsContainer.AddOneFrameObjects(_systems);
            _takeDamageSystemsContainer.AddOneFrameObjects(_systems);
        }

        protected override void AddInjections()
        {
            base.AddInjections();
            
            _movementSystemsContainer.AddInjectors(_systems);
            _takeDamageSystemsContainer.AddInjectors(_systems);
        }
    }
}
