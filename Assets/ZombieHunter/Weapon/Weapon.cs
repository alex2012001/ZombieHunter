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

        public Transform container1;
        
        private bool _shoot;
        private int _effectDelay = 100;

        private Bullet.Bullet _bullet;
        
        private void Start()
        {
            _bullet = Resources.Load<Bullet.Bullet>("Bullet");
            StartCoroutine(Cor());
        }

        public void Shoot(Transform container)
        {
            if (!_shoot)
            {
                _shoot = true;
                
                OnShoot?.Invoke();
                
                var obj = Instantiate(_bullet,shootPose);
                //obj.transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
                obj.transform.eulerAngles = transform.eulerAngles;
                Debug.Log(transform.eulerAngles);
                obj.transform.SetParent(container);

                EffectAsync(); 
                ShootDelay();
            }
            
        }
        private float GetAngleFromVector(Vector3 dir)
        {
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0)
                n += 360;
            return n;
        }

        private IEnumerator Cor()
        {
            Shoot(container1);
            yield return new WaitForSeconds(0.4f);
            StartCoroutine(Cor());
        }
        

        private void Update()
        {
            //transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            //transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
            
            // Debug.DrawRay(transform.position, new Vector3(
            //     transform.rotation.x,
            //     transform.rotation.y,
            //     transform.rotation.z), Color.red);
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
