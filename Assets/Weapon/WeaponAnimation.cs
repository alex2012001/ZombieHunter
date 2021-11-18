using System;
using UnityEngine;

namespace Weapon
{
    public class WeaponAnimation : MonoBehaviour
    {
        [SerializeField] private Weapon weapon;
        [SerializeField] private Animator animator;

        private static readonly int Shoot = Animator.StringToHash("Shoot");

        private void Start()
        {
            weapon.OnShoot += ShootAnim;
        }

        private void ShootAnim()
        {
            animator.SetTrigger(Shoot);
        }
    }
}
