using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "WeaponConfig")]
    public class WeaponConfig : ScriptableObject
    {
        public float Damage;
        public int FireRate;
        public AudioClip ShotSFx;
        public AudioSource AudioSource;
    }
}