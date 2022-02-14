using Leopotam.Ecs;
using UnityEngine;
using Weapon.Bullet;

namespace ZombieHunter.Weaon.Components
{
    public class ShootWeaponSystem : IEcsInitSystem, IEcsRunSystem
    {
        private Bullet _bullet;
        public void Init()
        {
            _bullet = Resources.Load<Bullet>("Bullet");
        }

        public void Run()
        {
            
        }
        
    }
}