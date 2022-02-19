using UnityEngine;
using ZombieHunter.EnemyWaveSystem;
using ZombieHunter.MovementSystem;

namespace ZombieHunter
{
    public class MainEcsStartup : EcsStartup
    {
        private readonly MovementSystemsContainer _movementSystemsContainer = new MovementSystemsContainer();
        private readonly WaveSystemContainer _waveSystemContainer = new WaveSystemContainer();
            
        protected override void AddSystems()
        {
            base.AddSystems();
                
            _movementSystemsContainer.AddSystems(_systems);
            _waveSystemContainer.AddSystems(_systems);
        }

        protected override void AddOneFrames()
        {
            base.AddOneFrames();
                
            _movementSystemsContainer.AddOneFrameObjects(_systems);
            _waveSystemContainer.AddOneFrameObjects(_systems);
        }

        protected override void AddInjections()
        {
            base.AddInjections();
                
            _movementSystemsContainer.AddInjectors(_systems);
            _waveSystemContainer.AddInjectors(_systems);
        }
    }
}
