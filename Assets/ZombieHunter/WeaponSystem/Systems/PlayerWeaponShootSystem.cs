using System.Threading.Tasks;
using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.WeaponSystem.Components;

namespace ZombieHunter.WeaponSystem.Systems
{
    public class PlayerWeaponShootSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld = null;
        private readonly BulletViewCreator _bulletViewCreator = null;
        
        private readonly EcsFilter<Tags.Player, WeaponSpawnData> _playerFilter = null;
        private readonly EcsFilter<Tags.Player, ShootRightHandEvent> _rightHandFilter = null;
        private readonly EcsFilter<Tags.Player, ShootLeftHandEvent> _leftHandFilter = null;

        private Transform _rightHandTransform;
        private Transform _leftHandTransform;
        private Transform _bulletContainer;
        private BulletView _bullet;
        
        private bool _shootRightGun;
        private bool _shootLeftGun;

        public void Init()
        {
            foreach (var i in _playerFilter)
            {
                ref var playerWeaponSpawnData = ref _playerFilter.Get2(i);

                _rightHandTransform = playerWeaponSpawnData.RightHandTransform;
                _leftHandTransform = playerWeaponSpawnData.LeftHandTransform;
                _bulletContainer = playerWeaponSpawnData.BulletContainer;
            }
            
            _bullet = Resources.Load<BulletView>("Bullet");
        }
        
        public void Run()
        {
            foreach (var i in _rightHandFilter)
            {
                if (!_shootRightGun)
                {
                    ref var shootRightHandEvent = ref _rightHandFilter.Get2(i);

                     var bullet = _bulletViewCreator.Create(_bullet, _rightHandTransform);
                     bullet.transform.SetParent(_bulletContainer);
                     bullet.Damage = shootRightHandEvent.Damage;

                     var entity = _ecsWorld.NewEntity();
                    
                     ref var model = ref entity.Get<ModelData>();
                     model.ModelTransform = bullet.transform;

                    entity.Get<BulletData>();
                    
                    DelayToDestroyBullet(bullet.gameObject,entity);

                    // var bullet = Object.Instantiate(_bullet, _rightHandTransform);
                    // bullet.transform.SetParent(_bulletContainer);
                    RightShootDelay(shootRightHandEvent.FireRate);
                }
            }

            // foreach (var i in _leftHandFilter)
            // {
            //     if (!_shootLeftGun)
            //     {
            //         ref var shootLeftHandEvent = ref _leftHandFilter.Get2(i);
            //         var bullet = Object.Instantiate(_bullet, _leftHandTransform);
            //         bullet.transform.SetParent(_bulletContainer);
            //         LeftShootDelay(shootLeftHandEvent.FireRate);
            //     }
            // }
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

        private async void DelayToDestroyBullet(GameObject obj, EcsEntity entity)
        {
            await Task.Delay(1000);
            entity.Destroy();
            Object.Destroy(obj);
        }
    }
}