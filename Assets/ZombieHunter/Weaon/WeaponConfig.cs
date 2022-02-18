using UnityEngine;

namespace ZombieHunter.Weaon
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "WeaponConfig")]
    public class WeaponConfig : ScriptableObject
    {
        public int FireRate;
        public AudioClip ShotSFx;
        public AudioSource AudioSource;
        public GameObject Effect;
        public ParticleSystem System;
        public int EffectDelay;
    }
}