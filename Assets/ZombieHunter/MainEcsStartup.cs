using ZombieHunter.EnemyWaveSystem;
using ZombieHunter.MovementSystem;
using ZombieHunter.TakeDamageSystem;
using ZombieHunter.WeaponSystem;

namespace ZombieHunter
{
    public class MainEcsStartup : EcsStartup
    {
        private readonly MovementSystemsContainer _movementSystemsContainer = new MovementSystemsContainer();
        private readonly WaveSystemContainer _waveSystemContainer = new WaveSystemContainer();
        private readonly WeaponSystemContainer _weaponSystemContainer = new WeaponSystemContainer();
        private readonly TakeDamageSystemsContainer _takeDamageSystemsContainer = new TakeDamageSystemsContainer();
            
        protected override void AddSystems()
        {
            base.AddSystems();
                
            _movementSystemsContainer.AddSystems(_systems);
            _waveSystemContainer.AddSystems(_systems);
            _weaponSystemContainer.AddSystems(_systems);
            _takeDamageSystemsContainer.AddSystems(_systems);
        }

        protected override void AddOneFrames()
        {
            base.AddOneFrames();
                
            _movementSystemsContainer.AddOneFrameObjects(_systems);
            _waveSystemContainer.AddOneFrameObjects(_systems);
            _weaponSystemContainer.AddOneFrameObjects(_systems);
            _takeDamageSystemsContainer.AddOneFrameObjects(_systems);
        }

        protected override void AddInjections()
        {
            base.AddInjections();
                
            _movementSystemsContainer.AddInjectors(_systems); 
            _waveSystemContainer.AddInjectors(_systems);
            _weaponSystemContainer.AddInjectors(_systems);
            _takeDamageSystemsContainer.AddInjectors(_systems);
        }
    }
}
