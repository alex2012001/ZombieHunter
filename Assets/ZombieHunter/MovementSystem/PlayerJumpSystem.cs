using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.MovementSystem.Events;

namespace ZombieHunter.MovementSystem
{
    sealed class PlayerJumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tags.Player, GroundCheckData, JumpData, JumpEvent>
            .Exclude<BlockJumpData> _jumpFilter = null;

        public void Run()
        {
            foreach (var i in _jumpFilter)
            { 
                ref var entity = ref _jumpFilter.GetEntity(i);
                ref var groundCheck = ref _jumpFilter.Get2(i);
                ref var jumpComponent = ref _jumpFilter.Get3(i);
                ref var movable = ref entity.Get<MovableData>();
                ref var velocity = ref movable.Velocity;

                if(!groundCheck.IsGrounded) continue;
                
                velocity.y = Mathf.Sqrt(jumpComponent.Force * -2f * movable.Gravity);
                entity.Get<BlockJumpData>().Timer = 3f;
            }
        }
    }
}