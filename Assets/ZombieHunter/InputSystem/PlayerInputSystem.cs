using System.Threading.Tasks;
using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.MovementSystem.Events;
using ZombieHunter.WeaponSystem;
using ZombieHunter.WeaponSystem.Components;

namespace ZombieHunter.InputSystem
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tags.Player, DirectionData, ModelData> _movableFilter = null;
        private readonly EcsFilter<Tags.Player, JumpData> _jumpFilter = null;
        private readonly EcsFilter<Tags.RightPlayerWeapon, WeaponData> _rightWeaponFilter = null;
        private readonly EcsFilter<Tags.LeftPlayerWeapon, WeaponData> _leftWeaponFilter = null;
        
        private readonly PlayerInputConfig _inputConfig = null;
        
        private float _moveX;
        private float _moveZ;

        private bool _isRotatable = true;

        public void Run()
        {
            GetControllersInput();

            foreach (var i in _movableFilter)
            {
                ref var directionComponent = ref _movableFilter.Get2(i);
                ref var direction = ref directionComponent.Direction;

                direction.x = _moveX;
                direction.z = _moveZ;

                ref var model = ref _movableFilter.Get3(i);

                DirectionModifier(model.ModelTransform);
            }
        }

        private void ShootLeftHand()
        {
            foreach (var i in _leftWeaponFilter)
            {
                ref var entity = ref _movableFilter.GetEntity(i);
                ref var weaponData = ref _leftWeaponFilter.Get2(i);
                entity.Replace(new ShootLeftHandEvent { WeaponData = weaponData});
            }
        }

        private void ShootRightHand()
        {
            foreach (var i in _rightWeaponFilter)
            {
                ref var entity = ref _movableFilter.GetEntity(i);
                ref var weaponData = ref _rightWeaponFilter.Get2(i);
                entity.Replace(new ShootRightHandEvent {WeaponData = weaponData});
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
        }

        private void DirectionModifier(Transform playerTransform)
        {
            var axis = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
            if (_isRotatable)
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
            _isRotatable = false;
            await Task.Delay(_inputConfig.DelayPerRotate);
            _isRotatable = true;
        }

        private void GetControllersInput()
        {
            SetDirection();
            
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
        }
    }
}