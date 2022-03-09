using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MouseLookSystem.Components;
using ZombieHunter.MovementSystem.Components;

namespace ZombieHunter.MouseLookSystem
{
    sealed class MouseLookSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<ModelData, MouseLookDirectionData> _mouseInputFilter = null;
        
        private readonly EcsStartup.DevelopMode _devMode = null;
        
        private Quaternion _startTransformRotation;

        public void Init()
        {
            if (!_devMode.Value)
            {
                return;
            }
            
            Cursor.lockState = CursorLockMode.Locked;
            _startTransformRotation = _mouseInputFilter.GetEntity(0).Get<ModelData>().ModelTransform.rotation;
        }
        
        public void Run()
        {
            if (!_devMode.Value)
            {
                return;
            }
            
            foreach (var i in _mouseInputFilter)
            {
                ref var model = ref _mouseInputFilter.Get1(i);
                ref var lookComponent = ref _mouseInputFilter.Get2(i);

                var axisX = lookComponent.Direction.x;
                var axisY = lookComponent.Direction.y;

                var rotateX = Quaternion.AngleAxis(axisX, Vector3.up * Time.deltaTime * lookComponent.MouseSensitivity);
                var rotateY = Quaternion.AngleAxis(axisY, Vector3.right * Time.deltaTime * lookComponent.MouseSensitivity);

                model.ModelTransform.rotation = _startTransformRotation * rotateX;
                lookComponent.CameraTransform.rotation = model.ModelTransform.rotation * rotateY;
            }   
        }
    }
}