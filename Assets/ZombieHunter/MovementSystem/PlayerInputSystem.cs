using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.Tags;

namespace ZombieHunter.MovementSystem
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionData> directionFilter = null;

        private float moveX;
        private float moveZ;
        
        public void Run()
        {
            SetDirection();
            
            foreach (var i in directionFilter)
            {
                ref var directionComponent = ref directionFilter.Get2(i);
                ref var direction = ref directionComponent.Direction;

                direction.x = moveX;
                direction.z = moveZ;
            }
        }

        private void SetDirection()
        {
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
        }
}
}