using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;

namespace ZombieHunter.MouseLookSystem
{
    sealed class MouseLookSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<ModelData, MouseLookDirectionData> _mouseLookFilter = null;

        private Quaternion _startTransformRotation;

        public void Init()
        {
            _startTransformRotation = _mouseLookFilter.GetEntity(0).Get<ModelData>().ModelTransform.rotation;
        }
        
        public void Run()
        {
            foreach (var i in _mouseLookFilter)
            {
                ref var model = ref _mouseLookFilter.Get1(i);
                ref var lookComponent = ref _mouseLookFilter.Get2(i);

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