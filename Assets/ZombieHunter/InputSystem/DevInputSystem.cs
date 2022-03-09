using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.InputSystem.MouseInputSystemComponent;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.MovementSystem.Events;
using ZombieHunter.WeaponSystem;
using ZombieHunter.WeaponSystem.Components;

namespace ZombieHunter.InputSystem
{
    public class DevInputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<Tags.Player, JumpData> _jumpFilter = null;
        private readonly EcsFilter<Tags.Player, DirectionData, ModelData> _movableFilter = null;
        private readonly EcsFilter<Tags.RightPlayerWeapon, WeaponData> _rightWeaponFilter = null;
        private readonly EcsFilter<Tags.LeftPlayerWeapon, WeaponData> _leftWeaponFilter = null;
        private readonly EcsFilter<ModelData, MouseLookDirectionData> _mouseInputFilter = null;

        private readonly EcsStartup.DevelopMode _devMode = null;
        
        private Quaternion _startTransformRotation;
        
        private float _axisX;
        private float _axisY;
        private float _moveX;
        private float _moveZ;

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
            
            GetMouseInput();
            GetKeyboardInput();
            
            foreach (var i in _movableFilter)
            {
                ref var directionComponent = ref _movableFilter.Get2(i);
                ref var direction = ref directionComponent.Direction;

                direction.x = _moveX;
                direction.z = _moveZ;
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
                
                lookComponent.Direction.x = _axisX;
                lookComponent.Direction.y = _axisY;
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
            GetMouseAxis();
            ClampAxis();
            GetMouseActions();
        }
        private void GetKeyboardInput()
        {
            SetDirection();
            GetKeyboardActions();
        }
    }
}