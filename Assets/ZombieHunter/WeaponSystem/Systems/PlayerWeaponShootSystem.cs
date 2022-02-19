using System.Threading.Tasks;
using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.WeaponSystem.Components;

namespace ZombieHunter.WeaponSystem.Systems
{
    public class PlayerWeaponShootSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<Tags.Player, WeaponSpawnData> _playerFilter = null;
        private readonly EcsFilter<Tags.Player, ShootRightHandEvent> _rightHandFilter = null;
        private readonly EcsFilter<Tags.Player, ShootLeftHandEvent> _leftHandFilter = null;

        private Transform _rightHandTransform;
        private Transform _leftHandTransform;
        private BulletComponent _bullet;
        
        private bool _shootRightGun;
        private bool _shootLeftGun;

        public void Init()
        {
            foreach (var i in _playerFilter)
            {
                ref var playerWeaponSpawnData = ref _playerFilter.Get2(i);

                _rightHandTransform = playerWeaponSpawnData.RightHandTransform;
                _leftHandTransform = playerWeaponSpawnData.LeftHandTransform;
            }
            
            _bullet = Resources.Load<BulletComponent>("Bullet");
        }
        
        public void Run()
        {
            foreach (var i in _rightHandFilter)
            {
                if (!_shootRightGun)
                {
                    ref var shootRightHandEvent = ref _rightHandFilter.Get2(i);
                    Object.Instantiate(_bullet, _rightHandTransform);
                    RightShootDelay(shootRightHandEvent.FireRate);
                }
            }

            foreach (var i in _leftHandFilter)
            {
                if (!_shootLeftGun)
                {
                    ref var shootLeftHandEvent = ref _leftHandFilter.Get2(i);
                    Object.Instantiate(_bullet, _leftHandTransform);
                    LeftShootDelay(shootLeftHandEvent.FireRate);
                }
            }
        }

        private async void RightShootDelay(int fireRate)
        {
            _shootRightGun = true;
            await Task.Delay(fireRate);
            _shootRightGun = false;
        }
        
        private async void LeftShootDelay(int fireRate)
        {
            _shootLeftGun = true;
            await Task.Delay(fireRate);
            _shootLeftGun = false;
        }
    }
}