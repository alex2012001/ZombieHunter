using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.MovementSystem.Events;
using ZombieHunter.WeaponSystem;
using ZombieHunter.WeaponSystem.Components;

namespace ZombieHunter.InputSystem
{
    public class DevInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tags.Player, JumpData> _jumpFilter = null;
        private readonly EcsFilter<Tags.Player, DirectionData, ModelData> _movableFilter = null;
        private readonly EcsFilter<Tags.RightPlayerWeapon, WeaponData> _rightWeaponFilter = null;
        private readonly EcsFilter<Tags.LeftPlayerWeapon, WeaponData> _leftWeaponFilter = null;
       
        private readonly EcsStartup.DevelopMode _devMode = null;
        
        private float _moveX;
        private float _moveZ;
        
        public void Run()
        {
            if (!_devMode.Value)
            {
                return;
            }
            
            SetDirection();
            
            foreach (var i in _movableFilter)
            {
                ref var directionComponent = ref _movableFilter.Get2(i);
                ref var direction = ref directionComponent.Direction;

                direction.x = _moveX;
                direction.z = _moveZ;
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
                ShootRightHand();
            }
        }
        private void ShootLeftHand()
        {
            foreach (var i in _leftWeaponFilter)
            {
                ref var entity = ref _movableFilter.GetEntity(i);
                ref var weaponData = ref _leftWeaponFilter.Get2(i);
                entity.Replace(new ShootLeftHandEvent { Damage = weaponData.Damage, FireRate = weaponData.FireRate});
            }
        }

        private void ShootRightHand()
        {
            foreach (var i in _rightWeaponFilter)
            {
                ref var entity = ref _movableFilter.GetEntity(i);
                ref var weaponData = ref _rightWeaponFilter.Get2(i);
                entity.Replace(new ShootRightHandEvent { Damage = weaponData.Damage, FireRate = weaponData.FireRate});
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
            _moveX = Input.GetAxis("Horizontal");
            _moveZ = Input.GetAxis("Vertical");
        }
    }
}