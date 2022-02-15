using Leopotam.Ecs;
using Voody.UniLeo;
using UnityEngine;
using ZombieHunter.MovementSystem;

namespace ZombieHunter
{
    public abstract class EcsStartup : MonoBehaviour
    {
        [SerializeField] private bool developmentMode;
        
        protected EcsWorld _world;
        protected EcsSystems _systems;

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
        
        private void Update()
        {
            _systems.Run();
        }

        protected virtual void AddInjections()
        {
            _systems
                .Inject(new DevelopMode(developmentMode));
        }
        
        protected virtual void AddOneFrames()
        {
            
        }

        protected virtual void AddSystems()
        {
            
        }

        protected virtual void OnDestroy()
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
        
        public class DevelopMode
        {
            public bool Value { get; }

            public DevelopMode(bool value)
            {
                Value = value;
            }
        }
    }
}
