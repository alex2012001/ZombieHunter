using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.Weaon.Components
{
    public class WeaponSpawnComponent : MonoProvider<WeaponSpawnData>
    {
        
    }

    [Serializable]
    public struct WeaponSpawnData
    {
        public Transform WeaponSpawnPosition;
    }
}