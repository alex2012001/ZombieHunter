using System;
using UnityEngine;

namespace User
{
    public class ShootController : MonoBehaviour
    {
        [SerializeField] private UserInput input;
        [SerializeField] private Weapon.Weapon weapon;
        
        private void Start()
        {
            input.OnTap += Shoot;
        }

        private void Shoot(object sender, UserInputEventArgs e)
        {
            weapon.Shoot(e.TapRay);
        }
        
    }
}
