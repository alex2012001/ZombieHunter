using UnityEngine;

namespace ZombieHunter.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public float HealthPoints;
        public GameObject Particle;
        public float TimeLivePartycle;
        public float Damage;
    }
   
}