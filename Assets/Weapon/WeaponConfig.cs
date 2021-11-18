using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "WeaponConfig")]
    public class WeaponConfig : ScriptableObject
    {
        public Weapon Prefab;
        public Vector3 SpawnPosition;
        public float Damage;
        public int FireRate;
        public AudioClip ShotSFx;
        public AudioSource AudioSource;
    }
}