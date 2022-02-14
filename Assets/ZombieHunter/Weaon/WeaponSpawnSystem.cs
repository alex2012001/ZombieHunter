using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.Weaon.Components;

namespace ZombieHunter.Weaon
{
    public class WeaponSpawnSystem : IEcsInitSystem
    {
        private readonly EcsFilter<Tags.Player, ModelData, WeaponSpawnData> _playerFilter = null;

        public void Init()
        {
            foreach (var i in _playerFilter)
            {
                ref var gunRightHandSpawnPoint = ref _playerFilter.Get2(i).RightHandController;
                ref var gunLeftHandSpawnPoint = ref _playerFilter.Get2(i).LeftHandController;
                
                var weapon = Resources.Load("Handgun");

                GameObject.Instantiate(weapon, gunRightHandSpawnPoint);
                GameObject.Instantiate(weapon, gunLeftHandSpawnPoint);
            }
        }
    }
}