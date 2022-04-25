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
        private readonly ViewCreator _viewCreator = null;
        
        private readonly EcsFilter<Tags.Player, WeaponSpawnData> _playerFilter = null;
        private readonly EcsFilter<Tags.Player, ShootRightHandEvent> _rightHandFilter = null;
        private readonly EcsFilter<Tags.Player, ShootLeftHandEvent> _leftHandFilter = null;
        
        private Transform _bulletContainer;
        private BulletView _bullet;
        
        private bool _shootRightGun;
        private bool _shootLeftGun;
        private int _delayToDestroyBullet;
        
        public void Init()
        {
            foreach (var i in _playerFilter)
            {
                ref var playerWeaponSpawnData = ref _playerFilter.Get2(i);
                _bulletContainer = playerWeaponSpawnData.BulletContainer;
            }
            
            _bullet = Resources.Load<BulletView>("Bullet");
            
            var bulletConfig = Resources.Load<BulletConfig>("BulletConfig");
            _delayToDestroyBullet = bulletConfig.DelayToDestroy;
        }
        
        public void Run()
        {
            foreach (var i in _rightHandFilter)
            {
                if (!_shootRightGun)
                {
                    ref var shootRightHandEvent = ref _rightHandFilter.Get2(i);
                   
                    CreateBullet(shootRightHandEvent.WeaponData.Damage, shootRightHandEvent.WeaponData.FirePoint);

                    RightShootDelay(shootRightHandEvent.WeaponData.FireRate);
                }
            }

            foreach (var i in _leftHandFilter)
            {
                if (!_shootLeftGun)
                {
                    ref var shootLeftHandEvent = ref _leftHandFilter.Get2(i);
                    
                    CreateBullet(shootLeftHandEvent.WeaponData.Damage, shootLeftHandEvent.WeaponData.FirePoint);
                    
                    LeftShootDelay(shootLeftHandEvent.WeaponData.FireRate);
                }
            }
        }

        private void CreateBullet(float damage, Transform root)
        {
            var bullet = _viewCreator.Create(_bullet, root);
            bullet.transform.SetParent(_bulletContainer);
            bullet.Damage = damage;

            var entity = _ecsWorld.NewEntity();
                    
            ref var model = ref entity.Get<ModelData>();
            model.ModelTransform = bullet.transform;

            entity.Get<BulletData>();

            DelayToDestroyBullet(bullet,entity);
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

        private async void DelayToDestroyBullet(BulletView bullet, EcsEntity entity)
        {
            await Task.Delay(_delayToDestroyBullet * 1000);
            entity.Destroy();
            Object.Destroy(bullet.gameObject);
        }
    }
}