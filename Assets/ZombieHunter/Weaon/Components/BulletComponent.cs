using System;
using UnityEngine;
using Voody.UniLeo;

namespace ZombieHunter.Weaon
{
    public class BulletComponent: MonoProvider<BulletData>
    {
        
    }
    [Serializable]
    public struct BulletData
    {
        public float Speed;
        public int DelayToDestroy;
        public Transform Transform;
    }
}