using System.Threading.Tasks;
using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MouseLookSystem.Components;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.MovementSystem.Events;
using ZombieHunter.WeaponSystem;
using ZombieHunter.WeaponSystem.Components;

namespace ZombieHunter.PlayerInputSystem
{
    public class DevInputSystem : IEcsRunSystem, IEcsInitSystem
    { 
        private float _moveX;
        private float _moveZ;

        private bool _isRotateble = true;

        //Inject
        private readonly EcsFilter<Tags.Player, DirectionData, ModelData> _movableFilter = null;
        private readonly EcsFilter<Tags.Player, JumpData> _jumpFilter = null;
        private readonly EcsFilter<Tags.RightPlayerWeapon, WeaponData> _rightWeaponFilter = null;
        private readonly EcsFilter<Tags.LeftPlayerWeapon, WeaponData> _leftWeaponFilter = null;
        private readonly EcsFilter<ModelData, MouseLookDirectionData> _mouseLookFilter = null;
        
        private readonly EcsStartup.DevelopMode _devMode = null;
        private readonly PlayerInputConfig _inputConfig = null;
      

        private Quaternion _startTransformRotation;

        public void Init()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _startTransformRotation = _mouseLookFilter.GetEntity(0).Get<ModelData>().ModelTransform.rotation;
        }
        
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