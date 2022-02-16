using UnityEngine;
using ZombieHunter.MovementSystem;

namespace ZombieHunter
{
    public class MainEcsStartup : EcsStartup
    {
    private readonly MovementSystemsContainer _movementSystemsContainer = new MovementSystemsContainer();
        
    protected override void AddSystems()
    {
        base.AddSystems();
            
        _movementSystemsContainer.AddSystems(_systems);
    }

    protected override void AddOneFrames()
    {
        base.AddOneFrames();
            
        _movementSystemsContainer.AddOneFrameObjects(_systems);
    }

    protected override void AddInjections()
    {
        base.AddInjections();
            
        _movementSystemsContainer.AddInjectors(_systems);
    }
    }
}
