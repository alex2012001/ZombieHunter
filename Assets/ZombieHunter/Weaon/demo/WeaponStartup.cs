namespace ZombieHunter.Weaon
{
    public class WeaponStartup : EcsStartup
    {
        private WeaponSystemContainer _weaponSystemContainer = new WeaponSystemContainer();
        
        protected override void AddSystems()
        {
            _weaponSystemContainer.AddSystems(_systems);
        }

        protected override void AddOneFrames()
        {
            _weaponSystemContainer.AddOneFrameObjects(_systems);
        }

        protected override void AddInjections()
        {
            _weaponSystemContainer.AddInjectors(_systems);
        }
        
    }
}