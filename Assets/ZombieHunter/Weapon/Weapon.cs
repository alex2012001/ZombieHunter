using System;
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
                    //obj.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
                
                obj.transform.SetParent(container);
                
                
                EffectAsync(); 
                ShootDelay();
            }
            
        }

        private void Update()
        {
            transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
            
            Debug.DrawRay(transform.position, new Vector3(
                transform.rotation.x,
                transform.rotation.y,
                transform.rotation.z), Color.red);
            
            Debug.DrawRay(transform.position, new Vector3(
                OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch).x,
                OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch).y,
                OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch).z
                ), Color.blue);
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
