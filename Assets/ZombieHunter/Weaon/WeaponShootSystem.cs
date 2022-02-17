using System.Threading.Tasks;
using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.Weaon;

namespace ZombieHunter.Weapon
{
    public class WeaponShootSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<Tags.Player,ModelData, WeaponData, ShootRightHandEvent> _rightHandFilter = null;
        private readonly EcsFilter<Tags.Player,ModelData, WeaponData, ShootLeftHandEvent> _leftHandFilter = null;
        private readonly EcsFilter<Tags.Player, ModelData> _bulletContainerFilter = null;


        private readonly Bullet _bullet = null;
        private readonly WeaponConfig _weaponConfig = null;

        private Transform _bulletContainer;

        private bool _shootRightGun;
        private bool _shootLeftGun;

        public void Init()
        {
            foreach (var i in _bulletContainerFilter)
            {
                _bulletContainer = _bulletContainerFilter.Get2(i).BulletContainer;
            }
        }
        public void Run()
        {
            foreach (var i in _rightHandFilter)
            {
                if (!_shootRightGun)
                {
                    _shootRightGun = true;
                    ref var rightGunShootPosition = ref _rightHandFilter.Get2(i).RightHandControllerPosition;
                    Shoot(rightGunShootPosition);
                    ShootDelayRightHand();
                }
            }

            foreach (var i in _leftHandFilter)
            {
                if (!_shootLeftGun)
                {
                    _shootLeftGun = true;
                    ref var leftGunShootPosition = ref _leftHandFilter.Get2(i).LeftHandControllerPosition;
                    Shoot(leftGunShootPosition);
                    ShootDelayLeftHand();
                }
            }
        }

        private void Shoot(Transform pos)
        {
            var bullet = GameObject.Instantiate(_bullet, pos);
            bullet.gameObject.transform.SetParent(_bulletContainer);
            bullet.SetParameters(_weaponConfig.Damage);
        }
        
        private async void ShootDelayRightHand()
        {
            await Task.Delay(_weaponConfig.FireRate);
            _shootRightGun = false;
        } 
        private async void ShootDelayLeftHand()
        {
            await Task.Delay(_weaponConfig.FireRate);
            _shootLeftGun = false;
        }
    }
}