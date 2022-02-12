using Leopotam.Ecs;

namespace ZombieHunter
{
    public interface IEcsContainer
    {
        void AddSystems(EcsSystems ecsSystems);
        void AddInjectors(EcsSystems ecsSystems);
        void AddOneFrameObjects(EcsSystems ecsSystems);
    }
}