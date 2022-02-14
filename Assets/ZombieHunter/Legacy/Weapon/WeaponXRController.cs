using System;
using UnityEngine;
using ZombieHunter.VRController;
using ZombieHunter.Weaon;

namespace ZombieHunter.Weapon
{
    public class WeaponXRController : MonoBehaviour
    {
        [SerializeField] private Transform rightControllerTransform;
        [SerializeField] private Transform lefttControllerTransform;
        
        [SerializeField] private Transform bulletsContainer;
        
        [SerializeField] private ControllerInput controllerInput;

        private WeaponLegacy _rightWeaponLegacy;
        private WeaponLegacy _leftWeaponLegacy;
            
        private void Start()
        {
            var weapon = Resources.Load<WeaponLegacy>("Handgun");
            _rightWeaponLegacy = Instantiate(weapon, rightControllerTransform);
            _leftWeaponLegacy = Instantiate(weapon, lefttControllerTransform);

            controllerInput.RIndexTrigger += RightShoot;
            controllerInput.LIndexTrigger += LeftShoot;
        }

        private void RightShoot()
        {
            _rightWeaponLegacy.Shoot(bulletsContainer);
        }

        private void LeftShoot()
        {
            _leftWeaponLegacy.Shoot(bulletsContainer);
        }
    }
}
