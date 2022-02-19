using System;
using System.Threading.Tasks;
using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.MovementSystem.Events;
using ZombieHunter.TakeDamageSystem.Components;
using ZombieHunter.WeaponSystem;

namespace ZombieHunter.PlayerInputSystem
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private float _moveX;
        private float _moveZ;

        private bool _isRotateble = true;

        //Inject
        private readonly EcsFilter<Tags.Player, DirectionData, ModelData> _movableFilter = null;
        private readonly EcsFilter<Tags.Player, JumpData> _jumpFilter = null;
        private readonly EcsFilter<Tags.Player, HealthpointsData> _healthpointsFilter = null;
        
        private readonly EcsStartup.DevelopMode _devMode = null;
        private readonly PlayerInputConfig _inputConfig = null;
        
        public void Run()
        {
            SetDirection();

            foreach (var i in _movableFilter)
            {
                ref var directionComponent = ref _movableFilter.Get2(i);
                ref var direction = ref directionComponent.Direction;

                direction.x = _moveX;
                direction.z = _moveZ;

                ref var model = ref _movableFilter.Get3(i);

                DirectionModifier(model.ModelTransform);
            }

            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                ShootRightHand();
            } 
            
            if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                ShootLeftHand();
            }
            
            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                Jump();   
            }

            if (!_devMode.Value)
            {
                return;
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (Input.GetMouseButtonDown(0))
            {
                ShootLeftHand();
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                ShootLeftHand();
            }
        }

        private void ShootLeftHand()
        {
            foreach (var i in _movableFilter)
            {
                ref var entity = ref _movableFilter.GetEntity(i);
                entity.Get<ShootLeftHandEvent>();
            }
        }
        
        private void ShootRightHand()
        {
            foreach (var i in _movableFilter)
            {
                ref var entity = ref _movableFilter.GetEntity(i);
                entity.Get<ShootRightHandEvent>();
            }
        }

        private void Jump()
        {
            foreach (var i in _jumpFilter)
            {
                ref var entity = ref _jumpFilter.GetEntity(i);
                entity.Get<JumpEvent>();
            }
        }
        

        private void SetDirection()
        {
            var axis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
           _moveX = axis.x;
           _moveZ = axis.y;

           if (!_devMode.Value)
           {
               return;
           }
           
           _moveX = Input.GetAxis("Horizontal");
           _moveZ = Input.GetAxis("Vertical");
        }

        private void DirectionModifier(Transform playerTransform)
        {
            var axis = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
            if (_isRotateble)
            {
                if (axis.x > _inputConfig.TopPrimaryThumbstickRotateLim)
                {
                    playerTransform.Rotate(0f,_inputConfig.RotateModifier,0f);
                    ModiferTimer();
                } 
                else if (axis.x < _inputConfig.LowPrimaryThumbstickRotateLim)
                {
                    playerTransform.Rotate(0f,-_inputConfig.RotateModifier,0f);
                    ModiferTimer();
                }
            }
        }

        private async void ModiferTimer()
        {
            _isRotateble = false;
            await Task.Delay(_inputConfig.DelayPerRotate);
            _isRotateble = true;
        }
    }
}