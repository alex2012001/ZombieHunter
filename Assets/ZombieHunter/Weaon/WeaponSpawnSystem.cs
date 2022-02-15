using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;

namespace ZombieHunter.Weaon
{
    public class WeaponSpawnSystem : IEcsInitSystem
    {
        private readonly EcsFilter<Tags.Player, ModelData, WeaponData> _playerFilter = null;

        private readonly global::Weapon _weapon = null;

        public void Init()
        {
            foreach (var i in _playerFilter)
            {
                ref var gunRightHandSpawnPoint = ref _playerFilter.Get2(i).RightHandControllerPosition;
                ref var gunLeftHandSpawnPoint = ref _playerFilter.Get2(i).LeftHandControllerPosition;

                GameObject.Instantiate(_weapon, gunRightHandSpawnPoint);
                GameObject.Instantiate(_weapon, gunLeftHandSpawnPoint);
            }
        }
    }
}