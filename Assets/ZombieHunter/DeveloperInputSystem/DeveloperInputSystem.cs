using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.ZInputSystem;

namespace ZombieHunter.DeveloperInputSystem
{
    sealed class DeveloperInputSystem : IEcsRunSystem
    {
        private float _axisX;
        private float _axisY;
        private float _moveX;
        private float _moveZ;

        private readonly EcsStartup.DevelopMode _devMode = null;

        public void Run()
        {
            if (!_devMode.Value)
            {
                return;
            }
            
            GetMouseInput();
            GetKeyboardInput();
        }
        
        private void ClampAxis()
        {
            _axisY = Mathf.Clamp(_axisY, -90f, 90f);
        }
        private void GetMouseAxis()
        {
            _axisX += Input.GetAxis("Mouse X");
            _axisY -= Input.GetAxis("Mouse Y");
        }
        private void GetMouseActions()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShootLeftHand();
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                ShootRightHand();
            }
        }
        private void SetDirection()
        {
            _moveX = Input.GetAxis("Horizontal");
            _moveZ = Input.GetAxis("Vertical");
        }
        private void GetKeyboardActions()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        
        private void GetMouseInput()
        {
            ClampAxis();
            GetMouseAxis();
            GetMouseActions();
        }
        private void GetKeyboardInput()
        {
            SetDirection();
            GetKeyboardActions();
        }
    }
}