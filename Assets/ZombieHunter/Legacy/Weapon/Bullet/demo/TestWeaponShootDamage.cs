using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeaponShootDamage : MonoBehaviour
{
    [SerializeField] private Weapon.Weapon _weapon;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _weapon.Shoot(transform);
        }
    }
}
