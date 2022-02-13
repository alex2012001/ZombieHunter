using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.Weaon.Components;

namespace ZombieHunter.Weaon
{
    public class WeaponSpawnSystem :  IEcsInitSystem
    {
        private readonly EcsFilter<WeaponSpawnData> _playerFilter = null;
            
        public void Init()
        {
            foreach (var i in _playerFilter)
            {
                ref var gunSpawnPoint = ref _playerFilter.Get1(i).WeaponSpawnPosition;
                
               var weapon = Resources.Load("Handgun");

                GameObject.Instantiate(weapon, gunSpawnPoint);
            }
        }
    }
}