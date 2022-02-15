using ZombieHunter.EnemyWaveSystem;

namespace ZombieHunter.MovementSystem
{
    public class EnemyWaveStartUp : EcsStartup
    {
        private WaveSystemContainer _waveSystemContainer = new WaveSystemContainer();
        
        protected override void AddSystems()
        {
            base.AddSystems();
            
            _waveSystemContainer.AddSystems(_systems);
        }

        protected override void AddOneFrames()
        {
            base.AddOneFrames();
            
            _waveSystemContainer.AddOneFrameObjects(_systems);
        }

        protected override void AddInjections()
        {
            base.AddInjections();
            
            _waveSystemContainer.AddInjectors(_systems);
        }
    }
}