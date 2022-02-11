using System;
using UnityEngine;
using ZombieHunter.VRController;

namespace ZombieHunter.Weapon
{
    public class WeaponXRController : MonoBehaviour
    {
        [SerializeField] private Transform rightControllerTransform;
        [SerializeField] private Transform lefttControllerTransform;
        
        [SerializeField] private Transform bulletsContainer;
        
        [SerializeField] private ControllerInput controllerInput;

        private global::Weapon.Weapon _rightWeapon;
        private global::Weapon.Weapon _leftWeapon;
            
        private void Start()
        {
            var weapon = Resources.Load<global::Weapon.Weapon>("Handgun");
            _rightWeapon = Instantiate(weapon, rightControllerTransform);
            _leftWeapon = Instantiate(weapon, lefttControllerTransform);

            controllerInput.RIndexTrigger += RightShoot;
            controllerInput.LIndexTrigger += LeftShoot;
        }

        private void RightShoot()
        {
            _rightWeapon.Shoot(bulletsContainer);
        }

        private void LeftShoot()
        {
            _leftWeapon.Shoot(bulletsContainer);
        }
    }
}
