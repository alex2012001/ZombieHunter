using System;
using UnityEngine;

namespace ZombieHunter.WeaponSystem.MeleeWeapon
{
    public class MeleeDamageble : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<BladeComponent>())
            {
                Destroy(gameObject);
            }
        }
    }
}
