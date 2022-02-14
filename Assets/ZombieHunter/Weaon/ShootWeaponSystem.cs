using System.Threading.Tasks;
using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.Weaon;

namespace ZombieHunter.Weapon
{
    public class ShootWeaponSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<Tags.Player, ModelData, WeaponData> _playerFilter = null;
        
        private readonly Bullet _bullet = null;
        private readonly WeaponConfig _weaponConfig = null;

        private Transform _bulletContainer;
        private int _effectDelay = 100;
        
        private ParticleSystem _particleSystem;
        private GameObject _gameEffect;
        

        private bool _shoot;

        public void Init()
        {
            foreach (var i in _playerFilter)
            {
                _bulletContainer = _playerFilter.Get2(i).BulletContainer;
            }

            _particleSystem = _weaponConfig.System;
            _gameEffect = _weaponConfig.Effect;
        }

        public void Run()
        {

            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger) || Input.GetKeyDown(KeyCode.R))
            {

                foreach (var i in _playerFilter)
                {
                    ref var gunRightHandSpawnPoint = ref _playerFilter.Get2(i).RightHandController;
                    Shoot(gunRightHandSpawnPoint);
                }
            }


            if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) || Input.GetKeyDown(KeyCode.L))
            {
                foreach (var i in _playerFilter)
                {
                    ref var gunLeftHandSpawnPoint = ref _playerFilter.Get2(i).LeftHandController;
                    Shoot(gunLeftHandSpawnPoint);
                }

            }
        }

        private void Shoot(Transform pos)
        {
            if (!_shoot)
            {
                _shoot = true;
                var bullet = GameObject.Instantiate(_bullet, pos);
                bullet.gameObject.transform.SetParent(_bulletContainer);
                bullet.SetParameters(_weaponConfig.Damage);
                EffectAsync();
                ShootDelay();
            }
        }
        
        private async void ShootDelay()
        {
            await Task.Delay(_weaponConfig.FireRate);
            _shoot = false;
        }
        
        private async void EffectAsync()
        {
            _particleSystem.Play();
            _gameEffect.SetActive(true);
            await Task.Delay(_effectDelay);
            _particleSystem.Stop();
            _gameEffect.SetActive(false);
        }
        
    }
}