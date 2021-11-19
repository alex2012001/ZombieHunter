using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Wave.Enemy;

namespace Weapon
{
    public class Weapon : MonoBehaviour
    {
        public Action OnShoot;

        [SerializeField] private Transform shootPose;
        
        [SerializeField] private WeaponConfig weaponConfig;
        [SerializeField] private GameObject effect;

        [SerializeField] private ParticleSystem system;

        private bool _shoot;
        private int _effectDelay = 100;

        private Bullet.Bullet _bullet;
        
        private void Start()
        {
            _bullet = Resources.Load<Bullet.Bullet>("Bullet");
        }

        public void Shoot(Transform container)
        {
            if (!_shoot)
            {
                _shoot = true;
                
                OnShoot?.Invoke();
                
                var obj = Instantiate(_bullet,shootPose);

                obj.transform.SetParent(container);

                EffectAsync(); 
                ShootDelay();
            }
            
        }

        private async void ShootDelay()
        {
            await Task.Delay(weaponConfig.FireRate);
            _shoot = false;
        }
        
        private async void EffectAsync()
        {
            system.Play();
            effect.SetActive(true);
            await Task.Delay(_effectDelay);
            system.Stop();
            effect.SetActive(false);
        }
    }
}
