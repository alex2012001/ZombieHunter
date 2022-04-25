using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.WeaponSystem.Components;

namespace ZombieHunter.WeaponSystem.Systems
{
    public class BulletFlyingSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<ModelData, BulletData> _bulletFilter = null;
        
        private float _speed;

        public void Init()
        {
            var bulletConfig = Resources.Load<BulletConfig>("BulletConfig");

            _speed = bulletConfig.Speed;
        }

        public void Run()
        {
            foreach (var i in _bulletFilter)
            {
                ref Transform tr = ref _bulletFilter.Get1(i).ModelTransform;
                if (tr != null)
                {
                    tr.Translate(new Vector3(0,0,_speed) * Time.deltaTime);
                }
            }
        }
    }
}