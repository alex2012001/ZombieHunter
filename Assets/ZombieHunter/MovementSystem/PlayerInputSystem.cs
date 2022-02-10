﻿using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;
using ZombieHunter.MovementSystem.Events;

namespace ZombieHunter.MovementSystem
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tags.Player, DirectionData> _directionFilter = null;
        private readonly EcsFilter<Tags.Player, JumpData> _jumpFilter = null;

        private float _moveX;
        private float _moveZ;
        
        public void Run()
        {
            SetDirection();
            
            foreach (var i in _directionFilter)
            {
                ref var directionComponent = ref _directionFilter.Get2(i);
                ref var direction = ref directionComponent.Direction;

                direction.x = _moveX;
                direction.z = _moveZ;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (var i in _jumpFilter)
                {
                    ref var entity = ref _jumpFilter.GetEntity(i);
                    entity.Get<JumpEvent>();
                }
            }
        }

        private void SetDirection()
        {
            _moveX = Input.GetAxis("Horizontal");
            _moveZ = Input.GetAxis("Vertical");
        }
}
}