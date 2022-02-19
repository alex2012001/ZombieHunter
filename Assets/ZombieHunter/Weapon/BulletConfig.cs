using UnityEngine;

namespace ZombieHunter.Weaon
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        public float Damage;
        public float Speed;
        public int DestroyDelay;
    }
}