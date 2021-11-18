using System;
using System.Threading.Tasks;
using UnityEngine;
using Wave.Enemy;

namespace Weapon
{
    public class Weapon : MonoBehaviour
    {
        public Action OnShoot;
        
        [SerializeField] private WeaponConfig weaponConfig;
        [SerializeField] private GameObject effect;

        [SerializeField] private ParticleSystem system;

        private bool _shoot;
        private int _effectDelay = 100;

        public void Shoot(Ray ray)
        {
            if (!_shoot)
            {
                _shoot = true;
                
                OnShoot?.Invoke();
            
                EffectAsync();
                ShootDelay();

                if (Physics.Raycast(ray, out var hit))
                {
                    if (hit.collider.GetComponent<Enemy>())
                    {
                        var enemy = hit.collider.GetComponent<Enemy>();
                        enemy.TakeDamage(weaponConfig.Damage);
                    }
                }
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
