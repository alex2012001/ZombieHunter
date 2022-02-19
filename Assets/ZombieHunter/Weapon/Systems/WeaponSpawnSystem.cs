using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;

namespace ZombieHunter.Weaon
{
    public class WeaponSpawnSystem : IEcsInitSystem
    {
        private readonly EcsFilter<Tags.Player, ModelData, WeaponData> _playerFilter = null;

        private readonly WeaponComponent _weaponComponent = null;

        public void Init()
        {
            foreach (var i in _playerFilter)
            {
                ref var gunRightHandSpawnPoint = ref _playerFilter.Get3(i).RightHandTransform;
                ref var gunLeftHandSpawnPoint = ref _playerFilter.Get3(i).LeftHandTransform;

                GameObject.Instantiate(_weaponComponent, gunRightHandSpawnPoint);
                GameObject.Instantiate(_weaponComponent, gunLeftHandSpawnPoint);
            }
        }
    }
}