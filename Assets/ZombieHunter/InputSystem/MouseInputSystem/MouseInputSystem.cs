using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MouseLookSystem.Components;
using ZombieHunter.MovementSystem.Components;

namespace ZombieHunter.MouseLookSystem
{
    sealed class MouseInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ModelData, MouseLookDirectionData> _mouseInputFilter = null;

        private float _axisX;
        private float _axisY;
        
        public void Run()
        {
            GetAxis();
            //ClampAxis();

            foreach (var i in _mouseInputFilter)
            {
                ref var lookComponent = ref _mouseInputFilter.Get2(i);

                lookComponent.Direction.x = _axisX;
                lookComponent.Direction.y = _axisY;
            }
        }

        private void ClampAxis()
        {
            _axisY = Mathf.Clamp(_axisY, -90f, 90f);
        }

        private void GetAxis()
        {
            _axisX += Input.GetAxis("Mouse X");
            _axisY -= Input.GetAxis("Mouse Y");
        }
    }
}