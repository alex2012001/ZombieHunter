using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using ZombieHunter.EnemyWaveSystem;
using ZombieHunter.MovementSystem.Events;

namespace ZombieHunter.MovementSystem
{
    public class EnemyWaveStartUp : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            AddInjections();
            AddOneFrames();
            AddSystems();
            
            _systems.ConvertScene();
            
            _systems.Init();
        }

        private void AddSystems()
        {
            _systems
                .Add(new BlockJumpSystem())
                .Add(new PlayerInputSystem())
                .Add(new MovementSystem())
                .Add(new GroundCheckSystem())
                .Add(new PlayerJumpSystem())
                .Add(new EnemyWaveSpawnSystem())
                .Add(new EnemyFollowPlayerSystem());
        }

        private void AddInjections()
        {
            
        }

        private void AddOneFrames()
        {
            _systems
                .OneFrame<JumpEvent>();
        }
        
        private void Update()
        {
            _systems.Run();
        }
        private void OnDestroy()
        {
            if (_systems == null)
            {
                return;
            }
            
            _systems.Destroy();
            _systems = null;
            
            _world.Destroy();
            _world = null;
        }
    }
}