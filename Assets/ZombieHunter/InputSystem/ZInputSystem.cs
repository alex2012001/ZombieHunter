using System.Threading.Tasks;
using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MouseLookSystem.Components;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.MovementSystem.Events;
using ZombieHunter.WeaponSystem;
using ZombieHunter.WeaponSystem.Components;

namespace ZombieHunter.ZInputSystem
{
    sealed class ZInputSystem : IEcsRunSystem
    {
        private float _axisX;
        private float _axisY;
        private float _moveX;
        private float _moveZ;

        private bool _isRotatable = true;

        //Inject
        private readonly EcsFilter<ModelData, MouseLookDirectionData> _mouseInputFilter = null;
        private readonly EcsFilter<Tags.Player, DirectionData, ModelData> _movableFilter = null;
        private readonly EcsFilter<Tags.Player, JumpData> _jumpFilter = null;
        private readonly EcsFilter<Tags.RightPlayerWeapon, WeaponData> _rightWeaponFilter = null;
        private readonly EcsFilter<Tags.LeftPlayerWeapon, WeaponData> _leftWeaponFilter = null;
        
        private readonly InputConfig _inputConfig = null;
        
        public void Run()
        {
            foreach (var i in _movableFilter)
            {
                ref var lookComponent = ref _mouseInputFilter.Get2(i);
                ref var directionComponent = ref _movableFilter.Get2(i);
                ref var direction = ref directionComponent.Direction;

                lookComponent.Direction.x = _axisX;
                lookComponent.Direction.y = _axisY;
                direction.x = _moveX;
                direction.z = _moveZ;

                ref var model = ref _movableFilter.Get3(i);

                DirectionModifier(model.ModelTransform);
            }
        }

        public void ShootLeftHand()
        {
            foreach (var i in _leftWeaponFilter)
            {
                ref var entity = ref _movableFilter.GetEntity(i);
                ref var weaponData = ref _leftWeaponFilter.Get2(i);
                entity.Replace(new ShootLeftHandEvent { Damage = weaponData.Damage, FireRate = weaponData.FireRate});
            }
        }

        public void ShootRightHand()
        {
            foreach (var i in _rightWeaponFilter)
            {
                ref var entity = ref _movableFilter.GetEntity(i);
                ref var weaponData = ref _rightWeaponFilter.Get2(i);
                entity.Replace(new ShootRightHandEvent { Damage = weaponData.Damage, FireRate = weaponData.FireRate});
            }
        }

        public void Jump()
        {
            foreach (var i in _jumpFilter)
            {
                ref var entity = ref _jumpFilter.GetEntity(i);
                entity.Get<JumpEvent>();
            }
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
    }
}