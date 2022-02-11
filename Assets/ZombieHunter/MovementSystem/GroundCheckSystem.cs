using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;

namespace ZombieHunter.MovementSystem
{
    sealed class GroundCheckSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tags.Player, GroundCheckData> _goriundCheckFilter = null;


        public void Run()
        {
            foreach (var i in _goriundCheckFilter)
            {
                ref var groundCheck = ref _goriundCheckFilter.Get2(i);

                groundCheck.IsGrounded =
                    Physics.CheckSphere(
                        groundCheck.GroundCheckSphere.position,
                        groundCheck.GroundDistance,
                        groundCheck.GroundMask);
            }
        }
    }
}