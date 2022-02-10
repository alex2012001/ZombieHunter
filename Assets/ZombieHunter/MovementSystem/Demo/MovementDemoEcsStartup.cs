using System;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.MovementSystem
{
    public class MovementDemoEcsStartup : MonoBehaviour
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
                .Add(new PlayerInputSystem())
                .Add(new MovementSystem());
        }

        private void AddInjections()
        {
            
        }

        private void AddOneFrames()
        {
            
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