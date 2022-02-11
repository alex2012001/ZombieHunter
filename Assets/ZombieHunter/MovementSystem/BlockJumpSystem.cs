using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;

namespace ZombieHunter.MovementSystem
{
    sealed class BlockJumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BlockJumpData> _blockJumpFilter = null;
        
        public void Run()
        {
            foreach (var i in _blockJumpFilter)
            {
                ref var entity = ref _blockJumpFilter.GetEntity(i);
                ref var block = ref _blockJumpFilter.Get1(i);
                block.Timer -= Time.deltaTime;

                if (block.Timer <= 0)
                {
                    entity.Del<BlockJumpData>();
                }
            }
        }
    }
}