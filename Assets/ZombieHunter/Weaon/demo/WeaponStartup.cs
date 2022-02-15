namespace ZombieHunter.Weaon
{
    public class WeaponStartup : EcsStartup
    {
        private WeaponSystemContainer _weaponSystemContainer = new WeaponSystemContainer();
        
        protected override void AddSystems()
        {
            base.AddSystems();
            
            _weaponSystemContainer.AddSystems(_systems);
        }

        protected override void AddOneFrames()
        {
            base.AddOneFrames();
            
            _weaponSystemContainer.AddOneFrameObjects(_systems);
        }

        protected override void AddInjections()
        {
            base.AddInjections();
            
            _weaponSystemContainer.AddInjectors(_systems);
        }
        
    }
}