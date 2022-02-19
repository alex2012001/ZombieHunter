using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.Tags;
using ZombieHunter.WeaponSystem.Components;

namespace ZombieHunter.WeaponSystem.Systems
{
    public class WeaponSpawnSystem : IEcsInitSystem
    {
        private readonly EcsFilter<Tags.Player, ModelData, WeaponSpawnData> _playerFilter = null;

        public void Init()
        {
            foreach (var i in _playerFilter)
            {
                var weapon = Resources.Load<WeaponComponent>("Handgun");
                
                ref var weaponSpawnData = ref _playerFilter.Get3(i);

                var rightGun = Object.Instantiate(weapon, weaponSpawnData.RightHandTransform);
                rightGun.gameObject.AddComponent<RightPlayerWeaponTag>(); // TODO: refactor
                
                var leftGun = Object.Instantiate(weapon, weaponSpawnData.LeftHandTransform);
                leftGun.gameObject.AddComponent<LeftPlayerWeaponTag>(); // TODO: refactor
            }
        }
    }
}