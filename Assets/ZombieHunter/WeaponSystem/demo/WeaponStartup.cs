using ZombieHunter.MovementSystem;

namespace ZombieHunter.WeaponSystem.demo
{
    public class WeaponStartup : EcsStartup
    {
        private MovementSystemsContainer _movementSystemsContainer = new MovementSystemsContainer();
        private WeaponSystemContainer _weaponSystemContainer = new WeaponSystemContainer();
        
        protected override void AddSystems()
        {
            base.AddSystems();
            
            _movementSystemsContainer.AddSystems(_systems);
            _weaponSystemContainer.AddSystems(_systems);
        }

        protected override void AddOneFrames()
        {
            base.AddOneFrames();
            
            _movementSystemsContainer.AddOneFrameObjects(_systems);
            _weaponSystemContainer.AddOneFrameObjects(_systems);
        }

        protected override void AddInjections()
        {
            base.AddInjections();
            
            _movementSystemsContainer.AddInjectors(_systems);
            _weaponSystemContainer.AddInjectors(_systems);
        }
        
    }
}