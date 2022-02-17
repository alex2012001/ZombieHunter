using System;
using Voody.UniLeo;

namespace ZombieHunter.TakeDamageSystem.Components
{
    public class HealthpointsComponent : MonoProvider<HealthpointsData>
    { }

    [Serializable]
    public struct HealthpointsData
    {
        public float Healthpoints;
    } 
}