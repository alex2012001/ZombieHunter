using UnityEngine;

namespace Wave.Enemy
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        public float HealthPoints;
        public GameObject Particle;
        public float TimeLivePartycle;
        public float Damage;

        public float Speed;
        public float AngularSpeed;
        public float StoppingDistance;
    }
}